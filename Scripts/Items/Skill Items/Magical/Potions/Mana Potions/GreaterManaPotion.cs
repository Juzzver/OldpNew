using System;
using Server;

namespace Server.Items
{
	public class GreaterManaPotion : BaseManaPotion
	{
		public override int MinMana { get { return 40; } }
		public override int MaxMana { get { return 45; } }
		public override double Delay { get { return 8.0; } }

		[Constructable]
		public GreaterManaPotion() : this( 1 )
		{
		}

		[Constructable]
		public GreaterManaPotion( int amount ) : base( PotionEffect.Mana, amount )
		{
			Name = "Greater Mana Refresh";
		}

		public GreaterManaPotion( Serial serial ) : base( serial )
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
	}
}
