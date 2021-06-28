using System;
using Server;

namespace Server.Items
{
	public class BerserkerPotion : BaseBerserkerPotion
	{
		public override int StrOffset{ get{ return 300; } }
		public override TimeSpan Duration{ get{ return TimeSpan.FromMinutes( 1.0 ); } }
		public override double Delay { get { return 1; } } // in Minutes

		[Constructable]
		public BerserkerPotion() : base( PotionEffect.Berserker )
		{
			Name = "Berserkers Potion";
		}

		public BerserkerPotion( Serial serial ) : base( serial )
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
