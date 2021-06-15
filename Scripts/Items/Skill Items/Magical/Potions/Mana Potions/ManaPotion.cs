using System;
using Server;

namespace Server.Items
{
	public class ManaPotion : BaseManaPotion
	{
		public override int MinMana { get { return 120; } }
		public override int MaxMana { get { return 120; } }
		public override double Delay { get { return 8.0; } }

		[Constructable]
		public ManaPotion() : this( 1 )
		{			
		}

		[Constructable]
		public ManaPotion( int amount ) : base( PotionEffect.Mana, amount )
		{
			Name = "Mana Refresh";
		}

		public ManaPotion( Serial serial ) : base( serial )
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
