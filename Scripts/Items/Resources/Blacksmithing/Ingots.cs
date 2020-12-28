using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseIngot : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}
		
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Resource = (CraftResource)reader.ReadInt();
					break;
				}
				case 0:
				{
					OreInfo info;

					switch ( reader.ReadInt() )
					{
						case 0: info = OreInfo.Iron; break;
						case 1: info = OreInfo.DullCopper; break;
						case 2: info = OreInfo.ShadowIron; break;
						case 3: info = OreInfo.Copper; break;
						case 4: info = OreInfo.Bronze; break;
						case 5: info = OreInfo.Gold; break;
						case 6: info = OreInfo.Agapite; break;
						case 7: info = OreInfo.Verite; break;
						case 8: info = OreInfo.Valorite; break;
						default: info = null; break;
					}

					m_Resource = CraftResources.GetFromOreInfo( info );
					break;
				}
			}
		}

		public BaseIngot( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseIngot( CraftResource resource, int amount ) : base( 0x1BF2 )
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseIngot( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1027154 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1027154 ); // ingots
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( !CraftResources.IsStandard( m_Resource ) )
			{
				int num = CraftResources.GetLocalizationNumber( m_Resource );

				if ( num > 0 )
					list.Add( num );
				else
					list.Add( CraftResources.GetName( m_Resource ) );
			}
		}

		public override int LabelNumber
		{
			get
			{
				//if ( m_Resource >= CraftResource.DullCopper && m_Resource <= CraftResource.Valorite )
				//	return 1042684 + (int)(m_Resource - CraftResource.DullCopper);

				return 1042692;
			}
		}
	}

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class IronIngot : BaseIngot
	{
		[Constructable]
		public IronIngot() : this( 1 )
		{
		}

		[Constructable]
		public IronIngot( int amount ) : base( CraftResource.Iron, amount )
		{
		}

		public IronIngot( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class CopperIngot : BaseIngot
	{
		[Constructable]
		public CopperIngot() : this( 1 )
		{
		}

		[Constructable]
		public CopperIngot( int amount ) : base( CraftResource.Copper, amount )
		{
		}

		public CopperIngot( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class BronzeIngot : BaseIngot
	{
		[Constructable]
		public BronzeIngot() : this( 1 )
		{
		}

		[Constructable]
		public BronzeIngot( int amount ) : base( CraftResource.Bronze, amount )
		{
		}

		public BronzeIngot( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class GoldIngot : BaseIngot
	{
		[Constructable]
		public GoldIngot() : this( 1 )
		{
		}

		[Constructable]
		public GoldIngot( int amount ) : base( CraftResource.Gold, amount )
		{
		}

		public GoldIngot( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BF2, 0x1BEF )]
	public class VeriteIngot : BaseIngot
	{
		[Constructable]
		public VeriteIngot() : this( 1 )
		{
		}

		[Constructable]
		public VeriteIngot( int amount ) : base( CraftResource.Verite, amount )
		{
		}

		public VeriteIngot( Serial serial ) : base( serial )
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
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class ValoriteIngot : BaseIngot
	{
		[Constructable]
		public ValoriteIngot() : this(1)
		{
		}

		[Constructable]
		public ValoriteIngot(int amount) : base(CraftResource.Valorite, amount)
		{
		}

		public ValoriteIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class SilverIngot : BaseIngot
	{
		[Constructable]
		public SilverIngot() : this(1)
		{
		}

		[Constructable]
		public SilverIngot(int amount) : base(CraftResource.Silver, amount)
		{
		}

		public SilverIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class StoneIngot : BaseIngot
	{
		[Constructable]
		public StoneIngot() : this(1)
		{
		}

		[Constructable]
		public StoneIngot(int amount) : base(CraftResource.Stone, amount)
		{
		}

		public StoneIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class GypsumIngot : BaseIngot
	{
		[Constructable]
		public GypsumIngot() : this(1)
		{
		}

		[Constructable]
		public GypsumIngot(int amount) : base(CraftResource.Gypsum, amount)
		{
		}

		public GypsumIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class TitanIngot : BaseIngot
	{
		[Constructable]
		public TitanIngot() : this(1)
		{
		}

		[Constructable]
		public TitanIngot(int amount) : base(CraftResource.Titan, amount)
		{
		}

		public TitanIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class BlueRockIngot : BaseIngot
	{
		[Constructable]
		public BlueRockIngot() : this(1)
		{
		}

		[Constructable]
		public BlueRockIngot(int amount) : base(CraftResource.BlueRock, amount)
		{
		}

		public BlueRockIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class AquaIngot : BaseIngot
	{
		[Constructable]
		public AquaIngot() : this(1)
		{
		}

		[Constructable]
		public AquaIngot(int amount) : base(CraftResource.Aqua, amount)
		{
		}

		public AquaIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class PlazmaIngot : BaseIngot
	{
		[Constructable]
		public PlazmaIngot() : this(1)
		{
		}

		[Constructable]
		public PlazmaIngot(int amount) : base(CraftResource.Plazma, amount)
		{
		}

		public PlazmaIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class CrystalIngot : BaseIngot
	{
		[Constructable]
		public CrystalIngot() : this(1)
		{
		}

		[Constructable]
		public CrystalIngot(int amount) : base(CraftResource.Crystal, amount)
		{
		}

		public CrystalIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class AcidIngot : BaseIngot
	{
		[Constructable]
		public AcidIngot() : this(1)
		{
		}

		[Constructable]
		public AcidIngot(int amount) : base(CraftResource.Acid, amount)
		{
		}

		public AcidIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class PlutoniumIngot : BaseIngot
	{
		[Constructable]
		public PlutoniumIngot() : this(1)
		{
		}

		[Constructable]
		public PlutoniumIngot(int amount) : base(CraftResource.Plutonium, amount)
		{
		}

		public PlutoniumIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class BloodRockIngot : BaseIngot
	{
		[Constructable]
		public BloodRockIngot() : this(1)
		{
		}

		[Constructable]
		public BloodRockIngot(int amount) : base(CraftResource.BloodRock, amount)
		{
		}

		public BloodRockIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class GloryIngot : BaseIngot
	{
		[Constructable]
		public GloryIngot() : this(1)
		{
		}

		[Constructable]
		public GloryIngot(int amount) : base(CraftResource.Glory, amount)
		{
		}

		public GloryIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class FrostIngot : BaseIngot
	{
		[Constructable]
		public FrostIngot() : this(1)
		{
		}

		[Constructable]
		public FrostIngot(int amount) : base(CraftResource.Frost, amount)
		{
		}

		public FrostIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class MeteorIngot : BaseIngot
	{
		[Constructable]
		public MeteorIngot() : this(1)
		{
		}

		[Constructable]
		public MeteorIngot(int amount) : base(CraftResource.Meteor, amount)
		{
		}

		public MeteorIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class BlueSteelIngot : BaseIngot
	{
		[Constructable]
		public BlueSteelIngot() : this(1)
		{
		}

		[Constructable]
		public BlueSteelIngot(int amount) : base(CraftResource.BlueSteel, amount)
		{
		}

		public BlueSteelIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class IridiumIngot : BaseIngot
	{
		[Constructable]
		public IridiumIngot() : this(1)
		{
		}

		[Constructable]
		public IridiumIngot(int amount) : base(CraftResource.Iridium, amount)
		{
		}

		public IridiumIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class WhiteStoneIngot : BaseIngot
	{
		[Constructable]
		public WhiteStoneIngot() : this(1)
		{
		}

		[Constructable]
		public WhiteStoneIngot(int amount) : base(CraftResource.WhiteStone, amount)
		{
		}

		public WhiteStoneIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class DiamondIngot : BaseIngot
	{
		[Constructable]
		public DiamondIngot() : this(1)
		{
		}

		[Constructable]
		public DiamondIngot(int amount) : base(CraftResource.Diamond, amount)
		{
		}

		public DiamondIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class MythrilIngot : BaseIngot
	{
		[Constructable]
		public MythrilIngot() : this(1)
		{
		}

		[Constructable]
		public MythrilIngot(int amount) : base(CraftResource.Mythril, amount)
		{
		}

		public MythrilIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class ShadowIngot : BaseIngot
	{
		[Constructable]
		public ShadowIngot() : this(1)
		{
		}

		[Constructable]
		public ShadowIngot(int amount) : base(CraftResource.Shadow, amount)
		{
		}

		public ShadowIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class LegendaryIngot : BaseIngot
	{
		[Constructable]
		public LegendaryIngot() : this(1)
		{
		}

		[Constructable]
		public LegendaryIngot(int amount) : base(CraftResource.Legendary, amount)
		{
		}

		public LegendaryIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
	[FlipableAttribute(0x1BF2, 0x1BEF)]
	public class LavaIngot : BaseIngot
	{
		[Constructable]
		public LavaIngot() : this(1)
		{
		}

		[Constructable]
		public LavaIngot(int amount) : base(CraftResource.Lava, amount)
		{
		}

		public LavaIngot(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}


	}
}
