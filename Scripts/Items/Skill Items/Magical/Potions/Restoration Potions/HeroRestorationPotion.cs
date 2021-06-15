using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class HeroRestorationPotion : BaseRestorationPotion
	{
		public override int MinHeal { get { return 600; } }
		public override int MaxHeal { get { return 600; } }
		public override int OverHitsBonus { get { return 300; } }

		[Constructable]
		public HeroRestorationPotion()
		{
			Name = "Hero Restoration Potion";
		}

		public HeroRestorationPotion( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			// To Do add player level checks // 13 lvl to use
			base.OnDoubleClick(from);
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
