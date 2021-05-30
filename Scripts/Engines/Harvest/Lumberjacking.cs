using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Engines.Harvest
{
	public class Lumberjacking : HarvestSystem
	{
		Mobile m_Harvester;
		Item m_HarvestTool;
		private static Lumberjacking m_System;

		public static Lumberjacking System
		{
			get
			{
				if (m_System == null)
					m_System = new Lumberjacking();

				return m_System;
			}
		}

		public static Lumberjacking GetLumberjackSystem(Item tool)
		{
			if (m_System == null)
				m_System = new Lumberjacking(tool);
			else if (m_System != null && m_System.m_HarvestTool != tool)
				m_System = new Lumberjacking(tool);

			return m_System;

		}

		private HarvestDefinition m_Definition;

		public HarvestDefinition Definition
		{
			get { return m_Definition; }
		}


		private Lumberjacking(Item harvTool = null)
		{
			HarvestResource[] res;

			m_HarvestTool = harvTool;

			HarvestVein[] veins;

			#region Lumberjacking
			HarvestDefinition lumber = new HarvestDefinition();

			// Resource banks are every 4x3 tiles
			lumber.BankWidth = 4;
			lumber.BankHeight = 3;

			// Every bank holds from 20 to 45 logs
			lumber.MinTotal = 4;
			lumber.MaxTotal = 4;

			// A resource bank will respawn its content every 20 to 30 minutes
			lumber.MinRespawn = TimeSpan.FromMinutes(20.0);
			lumber.MaxRespawn = TimeSpan.FromMinutes(30.0);

			// Skill checking is done on the Lumberjacking skill
			lumber.Skill = SkillName.Lumberjacking;

			// Set the list of harvestable tiles
			lumber.Tiles = m_TreeTiles;

			// Players must be within 2 tiles to harvest
			lumber.MaxRange = 2;

			// Ten logs per harvest action
			lumber.ConsumedPerHarvest = 1;
			lumber.ConsumedPerFeluccaHarvest = 1;

			// The chopping effect
			lumber.EffectActions = new int[] { 13 };
			lumber.EffectSounds = new int[] { 0x13E };
			lumber.EffectCounts = new int[] { 1, 2, 2, 2, 3 };//(Core.AOS ? new int[] { 1 } : new int[] { 1, 2, 2, 2, 3 });
			lumber.EffectDelay = TimeSpan.FromSeconds(3.6);
			lumber.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

			lumber.NoResourcesMessage = 500493; // There's not enough wood here to harvest.
			lumber.FailMessage = 500495; // You hack at the tree for a while, but fail to produce any useable wood.
			lumber.OutOfRangeMessage = 500446; // That is too far away.
			lumber.PackFullMessage = 500497; // You can't place any wood into your backpack!
			lumber.ToolBrokeMessage = 500499; // You broke your axe.

			if (Core.ML)
			{
				res = new HarvestResource[]
					{
					//Standard				
					new HarvestResource( 00.0, 00.0, 100.0, 100.0, AxeType.Standard, "You chop some Willow logs and put them into your backpack.", typeof( Log ) ),
					new HarvestResource( 10.0, 05.0, 100.0, 100.0, AxeType.Standard,"You chop some Aspen logs and put them into your backpack.", typeof( AspenLog ) ),
					new HarvestResource( 30.0, 10.0, 100.0, 100.0, AxeType.Standard,"You chop some Elven and put them into your backpack.", typeof( ElvenLog ) ),
					//Strong
					new HarvestResource( 50.0, 15.0, 100.0, 150.0, AxeType.Strong, "You chop some Dendroid logs and put them into your backpack.", typeof( DendroidLog ) ),
					new HarvestResource( 50.0, 20.0, 100.0, 150.0, AxeType.Strong, "You chop some Scorpion logs and put them into your backpack.", typeof( ScorpionLog ) ),
					new HarvestResource( 50.0, 23.0, 100.0, 150.0, AxeType.Strong, "You chop some Frozen logs and put them into your backpack.", typeof(FrozenLog ) ),
					//Hard
					new HarvestResource( 70.0, 27.0, 105.0, 180.0, AxeType.Hard, "You chop some Hamelion logs and put them into your backpack.", typeof( HamelionLog ) ),
					new HarvestResource( 70.0, 30.0, 108.0, 180.0, AxeType.Hard,     "You chop some Ice logs and put them into your backpack.", typeof( IceLog ) ),
					new HarvestResource( 70.0, 33.0, 110.0, 180.0, AxeType.Hard,     "You chop some Rose logs and put them into your backpack.", typeof( RoseLog ) ),
					new HarvestResource( 90.0, 36.0, 115.0, 180.0, AxeType.Hard,     "You chop some Dead logs and put them into your backpack.", typeof( DeadLog ) ),
					new HarvestResource( 90.0, 39.0, 120.0, 180.0, AxeType.Hard,     "You chop some Holy logs and put them into your backpack.", typeof( HolyLog ) ),
					//Mythril
					new HarvestResource( 100.0, 43.0, 125.0, 200.0, AxeType.Mythril, "You chop some Arian logs and put them into your backpack.", typeof( ArianLog ) ),
					new HarvestResource( 100.0, 46.0, 125.0, 200.0, AxeType.Mythril, "You chop some Millennium logs and put them into your backpack.", typeof( MillenniumLog ) ),
					new HarvestResource( 100.0, 49.0, 125.0, 200.0, AxeType.Mythril, "You chop some Mystic logs and put them into your backpack.", typeof( MysticLog ) ),
					new HarvestResource( 100.0, 53.0, 125.0, 200.0, AxeType.Mythril, "You chop some Terium logs and put them into your backpack.", typeof( TeriumLog ) ),

					//Legendary
					new HarvestResource( 100.0, 56.0, 130.0, 200.0, AxeType.Legendary, "You chop some Ancient logs and put them into your backpack.", typeof( AncientLog ) ),
					new HarvestResource( 100.0, 59.0, 130.0, 200.0, AxeType.Legendary, "You chop some Life logs and put them into your backpack.", typeof( LifeLog ) ),
					new HarvestResource( 100.0, 63.0, 130.0, 200.0, AxeType.Legendary, "You chop some Chaos logs and put them into your backpack.", typeof( ChaosLog ) ),
					new HarvestResource( 150.0, 66.0, 160.0, 200.0, AxeType.Legendary, "You chop some Legendary Black Oak logs and put them into your backpack.", typeof( LegendaryBlackOakLog ) ),
					};


				veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

				if (m_HarvestTool != null && (m_HarvestTool is BaseAxe) /*&& !(m_HarvestTool is Pickaxe)*/)
				{
					var tool = m_HarvestTool as BaseAxe;

					switch (tool.ToolType)
					{
						case AxeType.None:
							break;
						case AxeType.Standard:
							{
								veins = new HarvestVein[]
								{
								new HarvestVein( 50.0, 20.0, res[0], null ), // Willow
								new HarvestVein( 35.0, 40.0, res[1], null ), // Aspen
								new HarvestVein( 15.0, 60.0, res[2], null ), // Elven					
								};
							}
							break;
						case AxeType.Strong:
							{
								veins = new HarvestVein[]
								{
								new HarvestVein( 50.0, 90.0, res[3], null ), // Dendroid
								new HarvestVein( 30.0, 90.0, res[4], null ), // Scorpion
								new HarvestVein( 20.0, 90.0, res[5], null ), // Frozen
								};
							}
							break;
						case AxeType.Hard:
							{
								veins = new HarvestVein[]
								{
								new HarvestVein( 22.0, 92.0, res[6], null ), // Hamelion
								new HarvestVein( 21.0, 92.0, res[7], null ), // Ice
								new HarvestVein( 20.0, 92.0, res[8], null ), // Rose
								new HarvestVein( 20.0, 92.0, res[9], null ), // Dead
								new HarvestVein( 17.0, 92.0, res[10], null ),// Holy
								};
							}
							break;
						case AxeType.Mythril:
							{
								veins = new HarvestVein[]
								{
								new HarvestVein( 25.0, 94.0, res[11], null   ), // Arian
								new HarvestVein( 25.0, 94.0, res[12], null ), // Millennium
								new HarvestVein( 25.0, 94.0, res[13], null ), // Mystic
								new HarvestVein( 25.0, 94.0, res[14], null ), // Terium
								};
							}
							break;
						case AxeType.Legendary:
							{
								veins = new HarvestVein[]
								{
								new HarvestVein( 33.0, 97.0, res[15], null   ), // Ancient
								new HarvestVein( 33.0, 97.0, res[16], null ),	// Life
								new HarvestVein( 33.0, 97.0, res[17], null ),	// Chaos
								new HarvestVein( 01.0, 99.0, res[18], null   ), // Legendary
								};
							}
							break;
					}
				}

				lumber.BonusResources = new BonusHarvestResource[]
				{
					new BonusHarvestResource( 0, 83.9, null, null ),	//Nothing
					new BonusHarvestResource( 100, 10.0, 1072548, typeof( BarkFragment ) ),
					new BonusHarvestResource( 100, 03.0, 1072550, typeof( LuminescentFungi ) ),
					new BonusHarvestResource( 100, 02.0, 1072547, typeof( SwitchItem ) ),
					new BonusHarvestResource( 100, 01.0, 1072549, typeof( ParasiticPlant ) ),
					new BonusHarvestResource( 100, 00.1, 1072551, typeof( BrilliantAmber ) )
				};
			}
			else
			{
				res = new HarvestResource[]
				{
					new HarvestResource( 00.0, 00.0, 100.0, 500498, typeof( Log ) )
				};

				veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};
			}


			lumber.Resources = res;
			lumber.Veins = veins;

			lumber.RaceBonus = Core.ML;
			lumber.RandomizeVeins = Core.ML;

			m_Definition = lumber;
			Definitions.Add(lumber);
			#endregion
		}

		public override bool CheckHarvest(Mobile from, Item tool)
		{
			if (!base.CheckHarvest(from, tool))
				return false;

			if (tool.Parent != from)
			{
				from.SendLocalizedMessage(500487); // The axe must be equipped for any serious wood chopping.
				return false;
			}

			return true;
		}

		public override bool CheckHarvest(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
		{
			if (!base.CheckHarvest(from, tool, def, toHarvest))
				return false;

			if (tool.Parent != from)
			{
				from.SendLocalizedMessage(500487); // The axe must be equipped for any serious wood chopping.
				return false;
			}

			return true;
		}

		public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
		{
			if (toHarvest is Mobile)
				((Mobile)toHarvest).PrivateOverheadMessage(MessageType.Regular, 0x3B2, 500450, from.NetState); // You can only skin dead creatures.
			else if (toHarvest is Item)
				((Item)toHarvest).LabelTo(from, 500464); // Use this on corpses to carve away meat and hide
			else if (toHarvest is Targeting.StaticTarget || toHarvest is Targeting.LandTarget)
				from.SendLocalizedMessage(500489); // You can't use an axe on that.
			else
				from.SendLocalizedMessage(1005213); // You can't do that
		}

		public override void OnHarvestStarted(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
		{
			base.OnHarvestStarted(from, tool, def, toHarvest);

			if (Core.ML)
				from.RevealingAction();
		}

		public static void Initialize()
		{
			Array.Sort(m_TreeTiles);
		}

		#region Tile lists
		private static int[] m_TreeTiles = new int[]
			{
				0x4CCA, 0x4CCB, 0x4CCC, 0x4CCD, 0x4CD0, 0x4CD3, 0x4CD6, 0x4CD8,
				0x4CDA, 0x4CDD, 0x4CE0, 0x4CE3, 0x4CE6, 0x4CF8, 0x4CFB, 0x4CFE,
				0x4D01, 0x4D41, 0x4D42, 0x4D43, 0x4D44, 0x4D57, 0x4D58, 0x4D59,
				0x4D5A, 0x4D5B, 0x4D6E, 0x4D6F, 0x4D70, 0x4D71, 0x4D72, 0x4D84,
				0x4D85, 0x4D86, 0x52B5, 0x52B6, 0x52B7, 0x52B8, 0x52B9, 0x52BA,
				0x52BB, 0x52BC, 0x52BD,

				0x4CCE, 0x4CCF, 0x4CD1, 0x4CD2, 0x4CD4, 0x4CD5, 0x4CD7, 0x4CD9,
				0x4CDB, 0x4CDC, 0x4CDE, 0x4CDF, 0x4CE1, 0x4CE2, 0x4CE4, 0x4CE5,
				0x4CE7, 0x4CE8, 0x4CF9, 0x4CFA, 0x4CFC, 0x4CFD, 0x4CFF, 0x4D00,
				0x4D02, 0x4D03, 0x4D45, 0x4D46, 0x4D47, 0x4D48, 0x4D49, 0x4D4A,
				0x4D4B, 0x4D4C, 0x4D4D, 0x4D4E, 0x4D4F, 0x4D50, 0x4D51, 0x4D52,
				0x4D53, 0x4D5C, 0x4D5D, 0x4D5E, 0x4D5F, 0x4D60, 0x4D61, 0x4D62,
				0x4D63, 0x4D64, 0x4D65, 0x4D66, 0x4D67, 0x4D68, 0x4D69, 0x4D73,
				0x4D74, 0x4D75, 0x4D76, 0x4D77, 0x4D78, 0x4D79, 0x4D7A, 0x4D7B,
				0x4D7C, 0x4D7D, 0x4D7E, 0x4D7F, 0x4D87, 0x4D88, 0x4D89, 0x4D8A,
				0x4D8B, 0x4D8C, 0x4D8D, 0x4D8E, 0x4D8F, 0x4D90, 0x4D95, 0x4D96,
				0x4D97, 0x4D99, 0x4D9A, 0x4D9B, 0x4D9D, 0x4D9E, 0x4D9F, 0x4DA1,
				0x4DA2, 0x4DA3, 0x4DA5, 0x4DA6, 0x4DA7, 0x4DA9, 0x4DAA, 0x4DAB,
				0x52BE, 0x52BF, 0x52C0, 0x52C1, 0x52C2, 0x52C3, 0x52C4, 0x52C5,
				0x52C6, 0x52C7
			};
		#endregion
	}
}
