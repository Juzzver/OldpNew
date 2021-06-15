using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class AncientRestorationPotion : BaseRestorationPotion
	{
		public override int MinHeal { get { return 600; } }
		public override int MaxHeal { get { return 600; } }

		[Constructable]
		public AncientRestorationPotion()
		{
			Name = "Ancient Restoration Potion";
		}

		public AncientRestorationPotion( Serial serial ) : base( serial )
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
