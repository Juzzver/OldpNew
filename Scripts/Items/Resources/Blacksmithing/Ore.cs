using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.Items
{
	public abstract class BaseOre : Item
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}

		public abstract BaseIngot GetIngot();

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

		private static int RandomSize()
		{
			double rand = Utility.RandomDouble();

			if ( rand < 0.12 )
				return 0x19B7;
			else if ( rand < 0.18 )
				return 0x19B8;
			else if ( rand < 0.25 )
				return 0x19BA;
			else
				return 0x19B9;
		}

		public BaseOre( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseOre( CraftResource resource, int amount ) : base( RandomSize() )
		{
			Stackable = true;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
		}

		public BaseOre( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( Amount > 1 )
				list.Add( 1050039, "{0}\t#{1}", Amount, 1026583 ); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add( 1026583 ); // ore
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
				//	return 1042845 + (int)(m_Resource - CraftResource.DullCopper);

				return 1042853; // iron ore;
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			if ( RootParent is BaseCreature )
			{
				from.SendLocalizedMessage( 500447 ); // That is not accessible
			}
			else if ( from.InRange( this.GetWorldLocation(), 2 ) )
			{
				from.SendLocalizedMessage( 501971 ); // Select the forge on which to smelt the ore, or another pile of ore with which to combine it.
				from.Target = new InternalTarget( this );
			}
			else
			{
				from.SendLocalizedMessage( 501976 ); // The ore is too far away.
			}
		}

		private class InternalTarget : Target
		{
			private BaseOre m_Ore;

			public InternalTarget( BaseOre ore ) :  base ( 2, false, TargetFlags.None )
			{
				m_Ore = ore;
			}

			private bool IsForge( object obj )
			{
				if ( Core.ML && obj is Mobile && ((Mobile)obj).IsDeadBondedPet )
					return false;

				if ( obj.GetType().IsDefined( typeof( ForgeAttribute ), false ) )
					return true;

				int itemID = 0;

				if ( obj is Item )
					itemID = ((Item)obj).ItemID;
				else if ( obj is StaticTarget )
					itemID = ((StaticTarget)obj).ItemID;

				return ( itemID == 4017 || (itemID >= 6522 && itemID <= 6569) );
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Ore.Deleted )
					return;

				if ( !from.InRange( m_Ore.GetWorldLocation(), 2 ) )
				{
					from.SendLocalizedMessage( 501976 ); // The ore is too far away.
					return;
				}

				#region Combine Ore
				if ( targeted is BaseOre )
				{
					BaseOre ore = (BaseOre)targeted;

					if ( !ore.Movable )
					{
						return;
					}
					else if ( m_Ore == ore )
					{
						from.SendLocalizedMessage( 501972 ); // Select another pile or ore with which to combine this.
						from.Target = new InternalTarget( ore );
						return;
					}
					else if ( ore.Resource != m_Ore.Resource )
					{
						from.SendLocalizedMessage( 501979 ); // You cannot combine ores of different metals.
						return;
					}

					int worth = ore.Amount;

					if ( ore.ItemID == 0x19B9 )
						worth *= 8;
					else if ( ore.ItemID == 0x19B7 )
						worth *= 2;
					else
						worth *= 4;

					int sourceWorth = m_Ore.Amount;

					if ( m_Ore.ItemID == 0x19B9 )
						sourceWorth *= 8;
					else if ( m_Ore.ItemID == 0x19B7 )
						sourceWorth *= 2;
					else
						sourceWorth *= 4;

					worth += sourceWorth;

					int plusWeight = 0;
					int newID = ore.ItemID;

					if ( ore.DefaultWeight != m_Ore.DefaultWeight )
					{
						if ( ore.ItemID == 0x19B7 || m_Ore.ItemID == 0x19B7 )
						{
							newID = 0x19B7;
						}
						else if ( ore.ItemID == 0x19B9 )
						{
							newID = m_Ore.ItemID;
							plusWeight = ore.Amount * 2;
						}
						else
						{
							plusWeight = m_Ore.Amount * 2;
						}
					}

					if ( ( ore.ItemID == 0x19B9 && worth > 120000 ) || ( ( ore.ItemID == 0x19B8 || ore.ItemID == 0x19BA ) && worth > 60000 ) || ( ore.ItemID == 0x19B7 && worth > 30000 ) )
					{
						from.SendLocalizedMessage( 1062844 ); // There is too much ore to combine.
						return;
					}
					else if ( ore.RootParent is Mobile && ( plusWeight + ((Mobile)ore.RootParent).Backpack.TotalWeight ) > ((Mobile)ore.RootParent).Backpack.MaxWeight )
					{
						from.SendLocalizedMessage( 501978 ); // The weight is too great to combine in a container.
						return;
					}

					ore.ItemID = newID;

					if ( ore.ItemID == 0x19B9 )
						ore.Amount = worth / 8;
					else if ( ore.ItemID == 0x19B7 )
						ore.Amount = worth / 2;
					else
						ore.Amount = worth / 4;

					m_Ore.Delete();
					return;
				}
				#endregion

				if ( IsForge( targeted ) )
				{
					double difficulty;

					switch ( m_Ore.Resource )
					{
						default: difficulty = 50.0; break;
						case CraftResource.Bronze: difficulty = 65.0; break;
						case CraftResource.Silver: difficulty = 70.0; break;
						case CraftResource.Copper: difficulty = 75.0; break;
						case CraftResource.Gypsum: difficulty = 80.0; break;
						case CraftResource.Gold: difficulty = 85.0; break;
						case CraftResource.Titan: difficulty = 90.0; break;
						case CraftResource.Verite: difficulty = 95.0; break;
						case CraftResource.Valorite: difficulty = 99.0; break;
					}

					double minSkill = difficulty - 25.0;
					double maxSkill = difficulty + 25.0;

					if ( difficulty > 50.0 && difficulty > from.Skills[SkillName.Mining].Value )
					{
						from.SendLocalizedMessage( 501986 ); // You have no idea how to smelt this strange ore!
						return;
					}

					if ( m_Ore.ItemID == 0x19B7 && m_Ore.Amount < 2 )
					{
						from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						return;
					}

					if ( from.CheckTargetSkill( SkillName.Mining, targeted, minSkill, maxSkill ) )
					{
						int toConsume = m_Ore.Amount;

						if ( toConsume <= 0 )
						{
							from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						}
						else
						{
							if ( toConsume > 30000 )
								toConsume = 30000;

							int ingotAmount;

							if ( m_Ore.ItemID == 0x19B7 )
							{
								ingotAmount = toConsume / 2;

								if ( toConsume % 2 != 0 )
									--toConsume;
							}
							else if ( m_Ore.ItemID == 0x19B9 )
							{
								ingotAmount = toConsume * 2;
							}
							else
							{
								ingotAmount = toConsume;
							}

							BaseIngot ingot = m_Ore.GetIngot();
							ingot.Amount = ingotAmount;

							m_Ore.Consume( toConsume );
							from.AddToBackpack( ingot );
							//from.PlaySound( 0x57 );

							from.SendLocalizedMessage( 501988 ); // You smelt the ore removing the impurities and put the metal in your backpack.
						}
					}
					else
					{
						if ( m_Ore.Amount < 2 )
						{
							if ( m_Ore.ItemID == 0x19B9 )
								m_Ore.ItemID = 0x19B8;
							else
								m_Ore.ItemID = 0x19B7;
						}
						else
						{
							m_Ore.Amount /= 2;
						}

						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
					}
				}
			}
		}
	}

	public class IronOre : BaseOre
	{
		[Constructable]
		public IronOre() : this( 1 )
		{
		}

		[Constructable]
		public IronOre( int amount ) : base( CraftResource.Iron, amount )
		{
		}

		public IronOre( bool fixedSize ) : this( 1 )
		{
			if ( fixedSize )
				ItemID = 0x19B8;
		}

		public IronOre( Serial serial ) : base( serial )
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

		public override BaseIngot GetIngot()
		{
			return new IronIngot();
		}
	}

	public class CopperOre : BaseOre
	{
		[Constructable]
		public CopperOre() : this( 1 )
		{
		}

		[Constructable]
		public CopperOre( int amount ) : base( CraftResource.Copper, amount )
		{
		}

		public CopperOre( Serial serial ) : base( serial )
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

		public override BaseIngot GetIngot()
		{
			return new CopperIngot();
		}
	}

	public class BronzeOre : BaseOre
	{
		[Constructable]
		public BronzeOre() : this( 1 )
		{
		}

		[Constructable]
		public BronzeOre( int amount ) : base( CraftResource.Bronze, amount )
		{
		}

		public BronzeOre( Serial serial ) : base( serial )
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

		public override BaseIngot GetIngot()
		{
			return new BronzeIngot();
		}
	}

	public class GoldOre : BaseOre
	{
		[Constructable]
		public GoldOre() : this( 1 )
		{
		}

		[Constructable]
		public GoldOre( int amount ) : base( CraftResource.Gold, amount )
		{
		}

		public GoldOre( Serial serial ) : base( serial )
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

		public override BaseIngot GetIngot()
		{
			return new GoldIngot();
		}
	}

	public class VeriteOre : BaseOre
	{
		[Constructable]
		public VeriteOre() : this( 1 )
		{
		}

		[Constructable]
		public VeriteOre( int amount ) : base( CraftResource.Verite, amount )
		{
		}

		public VeriteOre( Serial serial ) : base( serial )
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

		public override BaseIngot GetIngot()
		{
			return new VeriteIngot();
		}
	}

	public class ValoriteOre : BaseOre
	{
		[Constructable]
		public ValoriteOre() : this( 1 )
		{
		}

		[Constructable]
		public ValoriteOre( int amount ) : base( CraftResource.Valorite, amount )
		{
		}

		public ValoriteOre( Serial serial ) : base( serial )
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

		public override BaseIngot GetIngot()
		{
			return new ValoriteIngot();
		}
	}
	public class SilverOre : BaseOre
	{
		[Constructable]
		public SilverOre() : this(1)
		{
		}

		[Constructable]
		public SilverOre(int amount) : base(CraftResource.Silver, amount)
		{
		}

		public SilverOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new SilverIngot();
		}
	}
	public class StoneOre : BaseOre
	{
		[Constructable]
		public StoneOre() : this(1)
		{
		}

		[Constructable]
		public StoneOre(int amount) : base(CraftResource.Stone, amount)
		{
		}

		public StoneOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new StoneIngot();
		}
	}
	public class GypsumOre : BaseOre
	{
		[Constructable]
		public GypsumOre() : this(1)
		{
		}

		[Constructable]
		public GypsumOre(int amount) : base(CraftResource.Gypsum, amount)
		{
		}

		public GypsumOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new GypsumIngot();
		}
	}
	public class TitanOre : BaseOre
	{
		[Constructable]
		public TitanOre() : this(1)
		{
		}

		[Constructable]
		public TitanOre(int amount) : base(CraftResource.Titan, amount)
		{
		}

		public TitanOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new TitanIngot();
		}
	}
	public class BlueRockOre : BaseOre
	{
		[Constructable]
		public BlueRockOre() : this(1)
		{
		}

		[Constructable]
		public BlueRockOre(int amount) : base(CraftResource.BlueRock, amount)
		{
		}

		public BlueRockOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new BlueRockIngot();
		}
	}
	public class AquaOre : BaseOre
	{
		[Constructable]
		public AquaOre() : this(1)
		{
		}

		[Constructable]
		public AquaOre(int amount) : base(CraftResource.Aqua, amount)
		{
		}

		public AquaOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new AquaIngot();
		}
	}
	public class PlazmaOre : BaseOre
	{
		[Constructable]
		public PlazmaOre() : this(1)
		{
		}

		[Constructable]
		public PlazmaOre(int amount) : base(CraftResource.Plazma, amount)
		{
		}

		public PlazmaOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new PlazmaIngot();
		}
	}
	public class CrystalOre : BaseOre
	{
		[Constructable]
		public CrystalOre() : this(1)
		{
		}

		[Constructable]
		public CrystalOre(int amount) : base(CraftResource.Crystal, amount)
		{
		}

		public CrystalOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new CrystalIngot();
		}
	}
	public class AcidOre : BaseOre
	{
		[Constructable]
		public AcidOre() : this(1)
		{
		}

		[Constructable]
		public AcidOre(int amount) : base(CraftResource.Acid, amount)
		{
		}

		public AcidOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new AcidIngot();
		}
	}
	public class PlutoniumOre : BaseOre
	{
		[Constructable]
		public PlutoniumOre() : this(1)
		{
		}

		[Constructable]
		public PlutoniumOre(int amount) : base(CraftResource.Plutonium, amount)
		{
		}

		public PlutoniumOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new PlutoniumIngot();
		}
	}
	public class BloodRockOre : BaseOre
	{
		[Constructable]
		public BloodRockOre() : this(1)
		{
		}

		[Constructable]
		public BloodRockOre(int amount) : base(CraftResource.BloodRock, amount)
		{
		}

		public BloodRockOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new BloodRockIngot();
		}
	}
	public class GloryOre : BaseOre
	{
		[Constructable]
		public GloryOre() : this(1)
		{
		}

		[Constructable]
		public GloryOre(int amount) : base(CraftResource.Glory, amount)
		{
		}

		public GloryOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new GloryIngot();
		}
	}
	public class FrostOre : BaseOre
	{
		[Constructable]
		public FrostOre() : this(1)
		{
		}

		[Constructable]
		public FrostOre(int amount) : base(CraftResource.Frost, amount)
		{
		}

		public FrostOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new FrostIngot();
		}
	}
	public class MeteorOre : BaseOre
	{
		[Constructable]
		public MeteorOre() : this(1)
		{
		}

		[Constructable]
		public MeteorOre(int amount) : base(CraftResource.Meteor, amount)
		{
		}

		public MeteorOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new MeteorIngot();
		}
	}
	public class BlueSteelOre : BaseOre
	{
		[Constructable]
		public BlueSteelOre() : this(1)
		{
		}

		[Constructable]
		public BlueSteelOre(int amount) : base(CraftResource.BlueSteel, amount)
		{
		}

		public BlueSteelOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new BlueSteelIngot();
		}
	}
	public class IridiumOre : BaseOre
	{
		[Constructable]
		public IridiumOre() : this(1)
		{
		}

		[Constructable]
		public IridiumOre(int amount) : base(CraftResource.Iridium, amount)
		{
		}

		public IridiumOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new IridiumIngot();
		}
	}
	public class WhiteStoneOre : BaseOre
	{
		[Constructable]
		public WhiteStoneOre() : this(1)
		{
		}

		[Constructable]
		public WhiteStoneOre(int amount) : base(CraftResource.WhiteStone, amount)
		{
		}

		public WhiteStoneOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new WhiteStoneIngot();
		}
	}
	public class DiamondOre : BaseOre
	{
		[Constructable]
		public DiamondOre() : this(1)
		{
		}

		[Constructable]
		public DiamondOre(int amount) : base(CraftResource.Diamond, amount)
		{
		}

		public DiamondOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new DiamondIngot();
		}
	}
	public class MythrilOre : BaseOre
	{
		[Constructable]
		public MythrilOre() : this(1)
		{
		}

		[Constructable]
		public MythrilOre(int amount) : base(CraftResource.Mythril, amount)
		{
		}

		public MythrilOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new MythrilIngot();
		}
	}
	public class ShadowOre : BaseOre
	{
		[Constructable]
		public ShadowOre() : this(1)
		{
		}

		[Constructable]
		public ShadowOre(int amount) : base(CraftResource.Shadow, amount)
		{
		}

		public ShadowOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new ShadowIngot();
		}
	}
	public class LegendaryOre : BaseOre
	{
		[Constructable]
		public LegendaryOre() : this(1)
		{
		}

		[Constructable]
		public LegendaryOre(int amount) : base(CraftResource.Legendary, amount)
		{
		}

		public LegendaryOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new LegendaryIngot();
		}
	}
	public class LavaOre : BaseOre
	{
		[Constructable]
		public LavaOre() : this(1)
		{
		}

		[Constructable]
		public LavaOre(int amount) : base(CraftResource.Lava, amount)
		{
		}

		public LavaOre(Serial serial) : base(serial)
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

		public override BaseIngot GetIngot()
		{
			return new LavaIngot();
		}
	}
}
