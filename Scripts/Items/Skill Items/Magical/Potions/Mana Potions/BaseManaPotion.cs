using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseManaPotion : BasePotion
	{
		public abstract int MinMana { get; }
		public abstract int MaxMana { get; }		

		public BaseManaPotion( PotionEffect effect, int amount ) : base( 0xF06, effect )
		{
			Hue = 1366;
		}

		public BaseManaPotion( Serial serial ) : base( serial )
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

		public override void Drink( Mobile from )
		{
			if ( from.Mana < from.ManaMax )
			{
				if (from.BeginAction(typeof(BaseManaPotion)))
				{
					from.Mana += Utility.RandomMinMax( MinMana, MaxMana );						

						BasePotion.PlayDrinkEffect( from );
						from.SendMessage( "You have restored some mana." );

						Amount--;

						if (Amount <= 0)
							Delete();

					Timer.DelayCall(TimeSpan.FromSeconds(Delay), new TimerStateCallback(ReleaseManaLock), from);
				}
				else
					from.LocalOverheadMessage(MessageType.Regular, 0x22, true, $"You must wait {Delay} seconds before using another mana potion");
			}
			else
			{
				from.SendMessage( "You decide against drinking this potion, as you are already at full mana." );
			}
		}

		private static void ReleaseManaLock(object state)
		{
			((Mobile)state).EndAction(typeof(BaseManaPotion));
		}
	}
}
