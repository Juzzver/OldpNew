using System;
using Server;

namespace Server.Items
{
	public class SmallBloodPotion : BaseBloodPotion
	{
		public override int MinHeal { get { return 100; } }
		public override int MaxHeal { get { return 100; } }
		public override double Delay{ get{ return 3.0; } }

		[Constructable]
		public SmallBloodPotion() : base( PotionEffect.Blood )
		{
			Name = "Small Blood Potion";
		}

		public SmallBloodPotion( Serial serial ) : base( serial )
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
