using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseBerserkerPotion : BasePotion
	{
		public abstract int StrOffset { get; }
		public abstract TimeSpan Duration { get; }
		public static double DamageAbsorbBonus { get { return 0.4; } }

		public static HashSet<Mobile> BerserkersTable { get; set; } = new HashSet<Mobile>();

		public BaseBerserkerPotion(PotionEffect effect) : base(0xF08, effect)
		{
			Hue = 1922;
		}

		public BaseBerserkerPotion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public bool DoEffect(Mobile from)
		{
			EndEffect(from);

			from.AddStatMod(new StatMod(StatType.Str, "Berserker", StrOffset, Duration));
			BerserkersTable.Add(from);

			Timer.DelayCall(Duration, () => EndEffect(from));

			from.FixedEffect(0x375A, 10, 15, 38, 1);
			from.PlaySound(0x1E7);
			from.SendMessage("You received Berserkers effect!");

			return true;
		}

		public override void Drink(Mobile from)
		{
			if (from.BeginAction(typeof(BaseBerserkerPotion)))
			{
				if (DoEffect(from))
				{
					BasePotion.PlayDrinkEffect(from);

					if (!Engines.ConPVP.DuelContext.IsFreeConsume(from))
						this.Consume();

					Timer.DelayCall(TimeSpan.FromMinutes(Delay), new TimerStateCallback(ReleaseBerserkerLock), from);
				}

			}
			else
			{
				from.LocalOverheadMessage(MessageType.Regular, 0x22, true, $"You must wait {Delay} minutes before using another berserker potion");
			}
		}

		private static void EndEffect (Mobile m)
		{
			if (BerserkersTable.Contains(m))
			{
				if (m.GetStatMod("Berserker") != null)
					m.RemoveStatMod("Berserker");

				m.SendMessage("Your Berserkers effect has ended.");
				BerserkersTable.Remove(m);
			}
		}

		public static bool IsUnderEffect(Mobile m)
		{
			return BerserkersTable.Contains(m);
		}

		private static void ReleaseBerserkerLock(object state)
		{
			((Mobile)state).EndAction(typeof(BaseBerserkerPotion));
		}
	}
}
