using System;

namespace Server.Items
{
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class Board : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get { return m_Resource; }
			set { m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber 
		{ 
			get
			{
				//if ( m_Resource >= CraftResource.ScorpionWood && m_Resource <= CraftResource.YewWood )
				//	return 1075052 + ( (int)m_Resource - (int)CraftResource.ScorpionWood );

				//switch ( m_Resource )
				//{
				//	case CraftResource.Elven: return 1075055;
				//	case CraftResource.Dendroid: return 1075056;
				//	case CraftResource.Aspen: return 1075062;	//WHY Osi.  Why?
				//}

				//return LabelNumber;

				return 0;
			} 
		}

		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public Board()
			: this( 1 )
		{
		}

		[Constructable]
		public Board( int amount )
			: this( CraftResource.WillowWood, amount )
		{
		}

		public Board( Serial serial )
			: base( serial )
		{
		}

		[Constructable]
		public Board( CraftResource resource ) : this( resource, 1 )
		{
		}

		[Constructable]
		public Board( CraftResource resource, int amount )
			: base( 0x1BD7 )
		{
			Stackable = true;
			Amount = amount;

			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
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

		

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 );

			writer.Write( (int)m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				case 2:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}

			if ( (version == 0 && Weight == 0.1) || ( version <= 2 && Weight == 2 ) )
				Weight = -1;

			if ( version <= 1 )
				m_Resource = CraftResource.RegularWood;
		}
	}


	public class AspenBoard : Board
	{
		[Constructable]
		public AspenBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public AspenBoard( int amount )
			: base( CraftResource.AspenWood, amount )
		{
		}

		public AspenBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class ElvenBoard : Board
	{
		[Constructable]
		public ElvenBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public ElvenBoard( int amount )
			: base( CraftResource.ElvenWood, amount )
		{
		}

		public ElvenBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class DendroidBoard : Board
	{
		[Constructable]
		public DendroidBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public DendroidBoard( int amount )
			: base( CraftResource.DendroidWood, amount )
		{
		}

		public DendroidBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class ScorpionBoard : Board
	{
		[Constructable]
		public ScorpionBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public ScorpionBoard( int amount )
			: base( CraftResource.ScorpionWood, amount )
		{
		}

		public ScorpionBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FrozenBoard : Board
	{
		[Constructable]
		public FrozenBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public FrozenBoard( int amount )
			: base( CraftResource.FrozenWood, amount )
		{
		}

		public FrozenBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class HamelionBoard : Board
	{
		[Constructable]
		public HamelionBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public HamelionBoard( int amount )
			: base( CraftResource.HamelionWood, amount )
		{
		}

		public HamelionBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	public class IceBoard : Board
	{
		[Constructable]
		public IceBoard()
			: this(1)
		{
		}

		[Constructable]
		public IceBoard(int amount)
			: base(CraftResource.IceWood, amount)
		{
		}

		public IceBoard(Serial serial)
			: base(serial)
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
	public class RoseBoard : Board
	{
		[Constructable]
		public RoseBoard()
			: this(1)
		{
		}

		[Constructable]
		public RoseBoard(int amount)
			: base(CraftResource.RoseWood, amount)
		{
		}

		public RoseBoard(Serial serial)
			: base(serial)
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
	public class DeadBoard : Board
	{
		[Constructable]
		public DeadBoard()
			: this(1)
		{
		}

		[Constructable]
		public DeadBoard(int amount)
			: base(CraftResource.DeadWood, amount)
		{
		}

		public DeadBoard(Serial serial)
			: base(serial)
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
	public class HolyBoard : Board
	{
		[Constructable]
		public HolyBoard()
			: this(1)
		{
		}

		[Constructable]
		public HolyBoard(int amount)
			: base(CraftResource.HolyWood, amount)
		{
		}

		public HolyBoard(Serial serial)
			: base(serial)
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
	public class ArianBoard : Board
	{
		[Constructable]
		public ArianBoard()
			: this(1)
		{
		}

		[Constructable]
		public ArianBoard(int amount)
			: base(CraftResource.ArianWood, amount)
		{
		}

		public ArianBoard(Serial serial)
			: base(serial)
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
	public class MillenniumBoard : Board
	{
		[Constructable]
		public MillenniumBoard()
			: this(1)
		{
		}

		[Constructable]
		public MillenniumBoard(int amount)
			: base(CraftResource.MillenniumWood, amount)
		{
		}

		public MillenniumBoard(Serial serial)
			: base(serial)
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
	public class MysticBoard : Board
	{
		[Constructable]
		public MysticBoard()
			: this(1)
		{
		}

		[Constructable]
		public MysticBoard(int amount)
			: base(CraftResource.MysticWood, amount)
		{
		}

		public MysticBoard(Serial serial)
			: base(serial)
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
	public class TeriumBoard : Board
	{
		[Constructable]
		public TeriumBoard()
			: this(1)
		{
		}

		[Constructable]
		public TeriumBoard(int amount)
			: base(CraftResource.TeriumWood, amount)
		{
		}

		public TeriumBoard(Serial serial)
			: base(serial)
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
	public class AncientBoard : Board
	{
		[Constructable]
		public AncientBoard()
			: this(1)
		{
		}

		[Constructable]
		public AncientBoard(int amount)
			: base(CraftResource.AncientWood, amount)
		{
		}

		public AncientBoard(Serial serial)
			: base(serial)
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
	public class LifeBoard : Board
	{
		[Constructable]
		public LifeBoard()
			: this(1)
		{
		}

		[Constructable]
		public LifeBoard(int amount)
			: base(CraftResource.LifeWood, amount)
		{
		}

		public LifeBoard(Serial serial)
			: base(serial)
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
	public class ChaosBoard : Board
	{
		[Constructable]
		public ChaosBoard()
			: this(1)
		{
		}

		[Constructable]
		public ChaosBoard(int amount)
			: base(CraftResource.ChaosWood, amount)
		{
		}

		public ChaosBoard(Serial serial)
			: base(serial)
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
	public class LegendaryBlackOakBoard : Board
	{
		[Constructable]
		public LegendaryBlackOakBoard()
			: this(1)
		{
		}

		[Constructable]
		public LegendaryBlackOakBoard(int amount)
			: base(CraftResource.LegendaryBlackOakWood, amount)
		{
		}

		public LegendaryBlackOakBoard(Serial serial)
			: base(serial)
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
