using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1bdd, 0x1be0 )]
	public class Log : Item, ICommodity, IAxe
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get { return m_Resource; }
			set { m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber { get { return CraftResources.IsStandard( m_Resource ) ? LabelNumber : 1075062 + ( (int)m_Resource - (int)CraftResource.RegularWood ); } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public Log() : this( 1 )
		{
		}

		[Constructable]
		public Log( int amount ) : this( CraftResource.WillowWood, amount )
		{
		}

		[Constructable]
		public Log( CraftResource resource )
			: this( resource, 1 )
		{
		}
		[Constructable]
		public Log( CraftResource resource, int amount )
			: base( 0x1BDD )
		{
			Stackable = true;
			Weight = 2.0;
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
		public Log( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int)m_Resource );
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
			}

			if ( version == 0 )
				m_Resource = CraftResource.RegularWood;
		}

		public virtual bool TryCreateBoards( Mobile from, double skill, Item item )
		{
			if ( Deleted || !from.CanSee( this ) ) 
				return false;
			else if ( from.Skills.Carpentry.Value < skill &&
				from.Skills.Lumberjacking.Value < skill )
			{
				item.Delete();
				from.SendLocalizedMessage( 1072652 ); // You cannot work this strange and unusual wood.
				return false;
			}
			base.ScissorHelper( from, item, 1, false );
			return true;
		}

		public virtual bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 0, new Board() ) )
				return false;
			
			return true;
		}
	}
	public class AspenLog : Log
	{
		[Constructable]
		public AspenLog() : this( 1 )
		{
		}
		[Constructable]
		public AspenLog( int amount ) 
			: base( CraftResource.AspenWood, amount )
		{
		}
		public AspenLog( Serial serial ) : base( serial )
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

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 100, new AspenBoard() ) )
				return false;

			return true;
		}
	}

	public class ElvenLog : Log
	{
		[Constructable]
		public ElvenLog()
			: this( 1 )
		{
		}
		[Constructable]
		public ElvenLog( int amount )
			: base( CraftResource.ElvenWood, amount )
		{
		}
		public ElvenLog( Serial serial )
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

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 100, new ElvenBoard() ) )
				return false;

			return true;
		}
	}

	public class DendroidLog : Log
	{
		[Constructable]
		public DendroidLog()
			: this( 1 )
		{
		}

		[Constructable]
		public DendroidLog( int amount )
			: base( CraftResource.DendroidWood, amount )
		{
		}

		public DendroidLog( Serial serial )
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

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 100, new DendroidBoard() ) )
				return false;

			return true;
		}
	}

	public class ScorpionLog : Log
	{
		[Constructable]
		public ScorpionLog()
			: this( 1 )
		{
		}

		[Constructable]
		public ScorpionLog( int amount )
			: base( CraftResource.ScorpionWood, amount )
		{
		}

		public ScorpionLog( Serial serial )
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

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 65, new ScorpionBoard() ) )
				return false;

			return true;
		}
	}

	public class FrozenLog : Log
	{
		[Constructable]
		public FrozenLog()
			: this( 1 )
		{
		}

		[Constructable]
		public FrozenLog( int amount )
			: base( CraftResource.FrozenWood, amount )
		{
		}

		public FrozenLog( Serial serial )
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

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 80, new FrozenBoard() ) )
				return false;

			return true;
		}
	}

	public class HamelionLog : Log
	{
		[Constructable]
		public HamelionLog()
			: this( 1 )
		{
		}

		[Constructable]
		public HamelionLog( int amount )
			: base( CraftResource.HamelionWood, amount )
		{
		}

		public HamelionLog( Serial serial )
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

		public override bool Axe( Mobile from, BaseAxe axe )
		{
			if ( !TryCreateBoards( from , 95, new HamelionBoard() ) )
				return false;

			return true;
		}
	}

	public class IceLog : Log
	{
		[Constructable]
		public IceLog()
			: this(1)
		{
		}

		[Constructable]
		public IceLog(int amount)
			: base(CraftResource.IceWood, amount)
		{
		}

		public IceLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new IceBoard()))
				return false;

			return true;
		}
	}
	public class RoseLog : Log
	{
		[Constructable]
		public RoseLog()
			: this(1)
		{
		}

		[Constructable]
		public RoseLog(int amount)
			: base(CraftResource.RoseWood, amount)
		{
		}

		public RoseLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new RoseBoard()))
				return false;

			return true;
		}
	}
	public class DeadLog : Log
	{
		[Constructable]
		public DeadLog()
			: this(1)
		{
		}

		[Constructable]
		public DeadLog(int amount)
			: base(CraftResource.DeadWood, amount)
		{
		}

		public DeadLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new DeadBoard()))
				return false;

			return true;
		}
	}
	public class HolyLog : Log
	{
		[Constructable]
		public HolyLog()
			: this(1)
		{
		}

		[Constructable]
		public HolyLog(int amount)
			: base(CraftResource.HolyWood, amount)
		{
		}

		public HolyLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new HolyBoard()))
				return false;

			return true;
		}
	}
	public class ArianLog : Log
	{
		[Constructable]
		public ArianLog()
			: this(1)
		{
		}

		[Constructable]
		public ArianLog(int amount)
			: base(CraftResource.ArianWood, amount)
		{
		}

		public ArianLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new ArianBoard()))
				return false;

			return true;
		}
	}
	public class MillenniumLog : Log
	{
		[Constructable]
		public MillenniumLog()
			: this(1)
		{
		}

		[Constructable]
		public MillenniumLog(int amount)
			: base(CraftResource.MillenniumWood, amount)
		{
		}

		public MillenniumLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new MillenniumBoard()))
				return false;

			return true;
		}
	}
	public class MysticLog : Log
	{
		[Constructable]
		public MysticLog()
			: this(1)
		{
		}

		[Constructable]
		public MysticLog(int amount)
			: base(CraftResource.MysticWood, amount)
		{
		}

		public MysticLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new MysticBoard()))
				return false;

			return true;
		}
	}
	public class TeriumLog : Log
	{
		[Constructable]
		public TeriumLog()
			: this(1)
		{
		}

		[Constructable]
		public TeriumLog(int amount)
			: base(CraftResource.TeriumWood, amount)
		{
		}

		public TeriumLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new TeriumBoard()))
				return false;

			return true;
		}
	}
	public class AncientLog : Log
	{
		[Constructable]
		public AncientLog()
			: this(1)
		{
		}

		[Constructable]
		public AncientLog(int amount)
			: base(CraftResource.AncientWood, amount)
		{
		}

		public AncientLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new AncientBoard()))
				return false;

			return true;
		}
	}
	public class ChaosLog : Log
	{
		[Constructable]
		public ChaosLog()
			: this(1)
		{
		}

		[Constructable]
		public ChaosLog(int amount)
			: base(CraftResource.ChaosWood, amount)
		{
		}

		public ChaosLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new ChaosBoard()))
				return false;

			return true;
		}
	}
	public class LifeLog : Log
	{
		[Constructable]
		public LifeLog()
			: this(1)
		{
		}

		[Constructable]
		public LifeLog(int amount)
			: base(CraftResource.LifeWood, amount)
		{
		}

		public LifeLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new LifeBoard()))
				return false;

			return true;
		}
	}
	public class LegendaryBlackOakLog : Log
	{
		[Constructable]
		public LegendaryBlackOakLog()
			: this(1)
		{
		}

		[Constructable]
		public LegendaryBlackOakLog(int amount)
			: base(CraftResource.LegendaryBlackOakWood, amount)
		{
		}

		public LegendaryBlackOakLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 95, new LegendaryBlackOakBoard()))
				return false;

			return true;
		}
	}
}
