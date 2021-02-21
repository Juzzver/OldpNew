using System;
using Server.Items;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{
	public enum PickaxeType
	{
		None,
		Regular,
		Blue,
		Red,
		Yellow,
		Green,
		Orange,
		White
	}

	[FlipableAttribute( 0xE86, 0xE85 )]
	public class Pickaxe : BaseAxe, IUsesRemaining
	{
		private PickaxeType m_PickType;
		[CommandProperty(AccessLevel.GameMaster)]
		public virtual PickaxeType PickType { get { return m_PickType; } set { m_PickType = value; } }
		public override HarvestSystem HarvestSystem{ get{ return Mining.GetMiningSystem(this); } }
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 13; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 35; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 25; } }
		public override int OldMinDamage{ get{ return 1; } }
		public override int OldMaxDamage{ get{ return 15; } }
		public override int OldSpeed{ get{ return 35; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		[Constructable]
		public Pickaxe() : base( 0xE86 )
		{
			Weight = 11.0;
			UsesRemaining = 50;
			ShowUsesRemaining = true;
			PickType = PickaxeType.Regular;
		}

		public Pickaxe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write((int)(m_PickType));
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_PickType = (PickaxeType)reader.ReadInt();
						goto case 0;
					}
				case 0:
					{
						ShowUsesRemaining = true;
						break;
					}
			}
			
		}
	}
}
