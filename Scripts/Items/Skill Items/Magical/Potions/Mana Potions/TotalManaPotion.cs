using System;
using Server;

namespace Server.Items
{
	public class TotalManaPotion : BaseManaPotion
	{
		public override int MinMana { get { return 250; } }
		public override int MaxMana { get { return 250; } }
		public override double Delay { get { return 11.0; } }

		[Constructable]
		public TotalManaPotion() : this( 1 )
		{
		}

		[Constructable]
		public TotalManaPotion( int amount ) : base( PotionEffect.Mana, amount )
		{
			Name = "Total Mana Refresh";
		}

		public TotalManaPotion( Serial serial ) : base( serial )
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
