using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class TotalRestorationPotion : BaseRestorationPotion
	{
		public override int MinHeal { get { return 400; } }
		public override int MaxHeal { get { return 400; } }

		[Constructable]
		public TotalRestorationPotion()
		{
			Name = "Total Restoration Potion";
		}

		public TotalRestorationPotion( Serial serial ) : base( serial )
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
