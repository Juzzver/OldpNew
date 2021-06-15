using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class RestorationPotion : BaseRestorationPotion
	{
		public override int MinHeal { get { return 250; } }
		public override int MaxHeal { get { return 250; } }

		[Constructable]
		public RestorationPotion()
		{
			Name = "Restoration Potion";
		}

		public RestorationPotion( Serial serial ) : base( serial )
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
