using Server.Items;
using System;

namespace Server.Items
{
	public class FrozenBow : Bow
	{
		public override int AosMinDamage { get { return CalculateMinDamage(); } }
		public override int AosMaxDamage { get { return CalculateMaxDamage(); } }
		public override int AosSpeed { get { return 25; } }
		public override float MlSpeed { get { return 4.25f; } }

		public int CalculateMinDamage()
		{
			switch (Level)
			{
				case 1: return 70;
				case 2: return 70;
				case 3: return 80;
				case 4: return 90;
				case 5: return 100;
			}

			return 70;
		}
		public int CalculateMaxDamage()
		{
			switch (Level)
			{
				case 1: return 90;
				case 2: return 100;
				case 3: return 110;
				case 4: return 120;
				case 5: return 130;
			}

			return 70;
		}


		[Constructable]
		public FrozenBow()
		{
			Name = "Frozen Bow";
			Hue = 1152;
		}

		public FrozenBow(Serial serial) : base(serial)
		{
		}

		public override void OnHit(Mobile attacker, Mobile defender, double damageBonus)
		{
			base.OnHit(attacker, defender, damageBonus);

			double chance = 0;

			switch (Level)
			{
				case 1: { chance = 10; } break;
				case 2: { chance = 20; } break;
				case 3: { chance = 25; } break;
				case 4: { chance = 29; } break;
				case 5: { chance = 33; } break;
			}

			if (chance > 0 && chance >= Utility.RandomDouble())
				DoParalyzeHit(attacker, defender);
		}

		public void DoParalyzeHit(Mobile attacker, Mobile defender)
		{
			if (defender != null && defender.Alive)
			{
				// Treat it as paralyze not as freeze, effect must be removed when damaged.
				defender.Paralyze(TimeSpan.FromSeconds(3));

				attacker.SendLocalizedMessage(1060163); // You deliver a paralyzing blow!
				defender.SendLocalizedMessage(1060164); // The attack has temporarily paralyzed you!
			}
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
	}
}
