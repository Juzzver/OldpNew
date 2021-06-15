using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public abstract class BasePoisonPotion : BasePotion
	{
		public abstract Poison Poison{ get; }

		public abstract double MinPoisoningSkill{ get; }
		public abstract double MaxPoisoningSkill{ get; }

		public BasePoisonPotion( PotionEffect effect ) : base( 0xF0A, effect )
		{
		}

		public BasePoisonPotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public void DoPoison( Mobile from )
		{
			from.ApplyPoison( from, Poison );
		}

		public override void Drink(Mobile from)
		{
			if (from.BeginAction(typeof(BasePoisonPotion)))
			{
				DoPoison(from);

				BasePotion.PlayDrinkEffect(from);

				if (!Engines.ConPVP.DuelContext.IsFreeConsume(from))
					this.Consume();

				Timer.DelayCall(TimeSpan.FromSeconds(Delay), new TimerStateCallback(ReleasePoisonLock), from);
			}
			else
				from.LocalOverheadMessage(MessageType.Regular, 0x22, true, $"You must wait {Delay} seconds before using another poison potion");
		}

		private static void ReleasePoisonLock(object state)
		{
			((Mobile)state).EndAction(typeof(BasePoisonPotion));
		}
	}
}
