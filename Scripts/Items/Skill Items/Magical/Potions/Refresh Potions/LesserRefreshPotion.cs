using System;
using Server;

namespace Server.Items
{
	public class LesserRefreshPotion : BaseRefreshPotion
	{
		public override double Refresh{ get{ return 0.15; } }
		public override double Delay { get { return 8.0; } }

		[Constructable]
		public LesserRefreshPotion() : base( PotionEffect.Refresh )
		{
			Name = "Lesser Refresh Potion";
		}

		public LesserRefreshPotion( Serial serial ) : base( serial )
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
