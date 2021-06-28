using System;
using Server;

namespace Server.Items
{
	public class BigBloodPotion : BaseHealPotion
	{
		public override int MinHeal { get { return 100; } }
		public override int MaxHeal { get { return 100; } }
		public override double Delay{ get{ return 0; } }

		[Constructable]
		public BigBloodPotion() : base( PotionEffect.Blood )
		{
			Name = "Big Blood Potion";
		}

		public BigBloodPotion( Serial serial ) : base( serial )
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
