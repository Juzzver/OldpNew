using System;
using Server.Items;

namespace Server.Engines.Craft
{
	public class DefAlchemy : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Alchemy;	}
		}

		public override int GumpTitleNumber
		{
			get { return 1044001; } // <CENTER>ALCHEMY MENU</CENTER>
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefAlchemy();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefAlchemy() : base( 1, 1, 1.25 )// base( 1, 1, 3.1 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !BaseTool.CheckAccessible( tool, from ) )
				return 1044263; // The tool must be on your person to use.

			return 0;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x242 );
		}

		private static Type typeofPotion = typeof( BasePotion );

		public static bool IsPotion( Type type )
		{
			return typeofPotion.IsAssignableFrom( type );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( IsPotion( item.ItemType ) )
				{
					from.AddToBackpack( new Bottle() );
					return 500287; // You fail to create a useful potion.
				}
				else
				{
					return 1044043; // You failed to create the item, and some of your materials are lost.
				}
			}
			else
			{
				from.PlaySound( 0x240 ); // Sound of a filling bottle

				if ( IsPotion( item.ItemType ) )
				{
					if ( quality == -1 )
						return 1048136; // You create the potion and pour it into a keg.
					else
						return 500279; // You pour the potion into a bottle...
				}
				else
				{
					return 1044154; // You create the item.
				}
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			// Refresh Potion
			index = AddCraft(typeof(LesserRefreshPotion), 1044530, 1044538, -25, 25.0, typeof(BlackPearl), 1044353, 3, 1044361);
			AddRes(index, typeof(EmptyJar), 1044529, 1, 500315);
			index = AddCraft( typeof( RefreshPotion ), 1044530, 1044538, 50, 100.0, typeof( BlackPearl ), 1044353, 6, 1044361 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );
			index = AddCraft( typeof( TotalRefreshPotion ), 1044530, 1044539, 50, 130.0, typeof( BlackPearl ), 1044353, 15, 1044361 );
			AddRes( index, typeof ( SmallRedFlask), 1044529, 1, 500315 );

			// Agility Potion
			index = AddCraft( typeof( AgilityPotion ), 1044531, 1044540, 40.0, 80.0, typeof( Bloodmoss ), 1044354, 3, 1044362 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );
			index = AddCraft( typeof( GreaterAgilityPotion ), 1044531, 1044541, 45.0, 100.0, typeof( Bloodmoss ), 1044354, 6, 1044362 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );

			// Nightsight Potion
			index = AddCraft( typeof( NightSightPotion ), 1044532, 1044542, -25.0, 25.0, typeof( SpidersSilk ), 1044360, 1, 1044368 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );

			// Heal Potion
			index = AddCraft( typeof( LesserHealPotion ), 1044533, 1044543, 20, 50.0, typeof( Ginseng ), 1044356, 5, 1044364 );
			AddRes( index, typeof ( EmptyJar ), 1044529, 1, 500315 );
			index = AddCraft( typeof( HealPotion ), 1044533, 1044544, 50.0, 85.0, typeof( Ginseng ), 1044356, 11, 1044364 );
			AddRes( index, typeof ( SmallEmptyFlask ), 1044529, 1, 500315 );
			index = AddCraft( typeof( GreaterHealPotion ), 1044533, 1044545, 60, 110.0, typeof( Ginseng ), 1044356, 25, 1044364 );
			AddRes( index, typeof ( SmallEmptyFlask ), 1044529, 2, 500315 );

			// Strength Potion
			index = AddCraft( typeof( StrengthPotion ), 1044534, 1044546, 40.0, 80.0, typeof( MandrakeRoot ), 1044357, 3, 1044365 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );
			index = AddCraft( typeof( GreaterStrengthPotion ), 1044534, 1044547, 50.0, 100.0, typeof( MandrakeRoot ), 1044357, 7, 1044365 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );

			// Poison Potion
			index = AddCraft( typeof( LesserPoisonPotion ), 1044535, 1044548, 40.0, 100.0, typeof( Nightshade ), 1044358, 3, 1044366 );
			AddRes( index, typeof ( EmptyJar), 1044529, 1, 500315 );
			index = AddCraft( typeof( PoisonPotion ), 1044535, 1044549, 60.0, 110.0, typeof( Nightshade ), 1044358, 9, 1044366 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );
			index = AddCraft( typeof( GreaterPoisonPotion ), 1044535, 1044550, 80.0, 130.0, typeof( Nightshade ), 1044358, 18, 1044366 );
			AddRes( index, typeof ( SmallEmptyFlask ), 1044529, 4, 500315 );
			index = AddCraft( typeof( DeadlyPoisonPotion ), 1044535, 1044551, 90.0, 140.0, typeof( Nightshade ), 1044358, 30, 1044366 );
			AddRes( index, typeof (SmallEmptyFlask), 1044529, 1, 500315 );

			// Cure Potion
			index = AddCraft( typeof( LesserCurePotion ), 1044536, 1044552, 20.0, 50.0, typeof( Garlic ), 1044355, 3, 1044363 );
			AddRes( index, typeof ( EmptyJar), 1044529, 1, 500315 );
			index = AddCraft( typeof( CurePotion ), 1044536, 1044553, 25.0, 75.0, typeof( Garlic ), 1044355, 6, 1044363 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );
			index = AddCraft( typeof( GreaterCurePotion ), 1044536, 1044554, 50.0, 115.0, typeof( Garlic ), 1044355, 9, 1044363 );
			AddRes( index, typeof ( SmallEmptyFlask ), 1044529, 1, 500315 );

			// Explosion Potion
			index = AddCraft( typeof( LesserExplosionPotion ), 1044537, 1044555, 5.0, 55.0, typeof( SulfurousAsh ), 1044359, 3, 1044367 );
			AddRes( index, typeof ( Bottle ), 1044529, 1, 500315 );
			index = AddCraft( typeof( ExplosionPotion ), 1044537, 1044556, 35.0, 85.0, typeof( SulfurousAsh ), 1044359, 7, 1044367 );
			AddRes( index, typeof ( SmallEmptyFlask ), 1044529, 3, 500315 );
			index = AddCraft( typeof( GreaterExplosionPotion ), 1044537, 1044557, 65.0, 115.0, typeof( SulfurousAsh ), 1044359, 18, 1044367 );
			AddRes( index, typeof (SmallEmptyFlask), 1044529, 2, 500315 );

			if( Core.SE )
			{
				index = AddCraft( typeof( SmokeBomb ), 1044537, 1030248, 90.0, 120.0, typeof( Eggs ), 1044477, 1, 1044253 );
				AddRes( index, typeof ( Ginseng ), 1044356, 3, 1044364 );
				SetNeededExpansion( index, Expansion.SE );

				// Conflagration Potions
				index = AddCraft( typeof(ConflagrationPotion), 1044109, 1072096, 55.0, 105.0, typeof(GraveDust), 1023983, 5, 1044253 );
				AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
				SetNeededExpansion(index, Expansion.SE);
				index = AddCraft( typeof(GreaterConflagrationPotion), 1044109, 1072099, 65.0, 115.0, typeof(GraveDust), 1023983, 10, 1044253 );
				AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
				SetNeededExpansion(index, Expansion.SE);
				// Confusion Blast Potions
				index = AddCraft( typeof(ConfusionBlastPotion), 1044109, 1072106, 55.0, 105.0, typeof(PigIron), 1023978, 5, 1044253 );
				AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
				SetNeededExpansion(index, Expansion.SE);
				index = AddCraft( typeof(GreaterConfusionBlastPotion), 1044109, 1072109, 65.0, 115.0, typeof(PigIron), 1023978, 10, 1044253 );
				AddRes( index, typeof(Bottle), 1044529, 1, 500315 );
				SetNeededExpansion(index, Expansion.SE);
			}

			#region Custom Oldp Potions
			index = AddCraft(typeof(InvisibilityPotion), "Magical", 1074860, 65.0, 115.0, typeof(SmallEmptyFlask), 1044529, 1, 500315);
			AddRes(index, typeof(EyeOfNewt), 1023975, 8, "You do not have enough eyes of newt to make that.");

			// Mana Potion
			index = AddCraft(typeof(LesserManaPotion), "Magical", "Lesser Mana Refresh", 60.0, 120.0, typeof(EyeOfNewt), "eyes of newt", 7, "You do not have enough eyes of newt to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 1, 500315);
			index = AddCraft(typeof(ManaPotion), "Magical", "Mana Refresh", 70.0, 120.0, typeof(EyeOfNewt), "eyes of newt", 12, "You do not have enough eyes of newt to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 1, 500315);
			index = AddCraft(typeof(GreaterManaPotion), "Magical", "Greater Mana Refresh", 75.0, 120.0, typeof(EyeOfNewt), "eyes of newt", 15, "You do not have enough eyes of newt to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 1, 500315);
			index = AddCraft(typeof(TotalManaPotion), "Magical", "Total Mana Refresh", 85.0, 120.0, typeof(EyeOfNewt), "eyes of newt", 20, "You do not have enough eyes of newt to make that.");
			AddRes(index, typeof(MandrakeRoot), 1044357, 10, 1044365);
			AddRes(index, typeof(SulfurousAsh), 1044359, 10, 1044367);
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 1, 500315);

			// Shrink Potion
			index = AddCraft(typeof(Xanthos.ShrinkSystem.ShrinkPotion), "Magical", "Shrink", 60.0, 120.0, typeof(ExecutionersCap), "executioners cap", 4, "You do not have enough executioners cap to make that.");
			AddRes(index, typeof(GhostBone), "Ghost Bone", 5, "You do not have enough ghost bones to make that.");
			AddRes(index, typeof(Gold), "Gold", 1000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 1, 500315);

			// Restoration
			index = AddCraft(typeof(RestorationPotion), "Magical", "Restoration", 83.0, 120.0, typeof(Ginseng), 1044356, 40, 1044364);
			AddRes(index, typeof(SulfurousAsh), 1044359, 10, 1044367);
			AddRes(index, typeof(SilverIngot), "Silver Ingot", 5, "You do not have enough silver ingots to make that.");
			AddRes(index, typeof(Gold), "Gold", 1000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 4, 500315);

			index = AddCraft(typeof(TotalRestorationPotion), "Magical", "Total Restoration", 95.0, 150.0, typeof(Ginseng), 1044356, 100, 1044364);
			AddRes(index, typeof(SulfurousAsh), 1044359, 30, 1044367);
			AddRes(index, typeof(SilverIngot), "Silver Ingot", 10, "You do not have enough silver ingots to make that.");
			AddRes(index, typeof(Gold), "Gold", 2000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 4, 500315);

			index = AddCraft(typeof(AncientRestorationPotion), "Magical", "Ancient Restoration", 120.0, 170.0, typeof(DragonBone), "Dragon Bone", 5, "You do not have enough dragon bones to make that.");
			AddRes(index, typeof(DragonWing), "Dragon Wing", 5, "You do not have enough dragon wings to make that.");
			AddRes(index, typeof(DragonHeart), "Dragon Heart", 5, "You do not have enough dragon bones to make that.");
			AddRes(index, typeof(BalronBone), "Balron Bone", 5, "You do not have enough balron bones to make that.");
			AddRes(index, typeof(Gold), "Gold", 5000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptySilverFlask), 1044529, 4, 500315);

			index = AddCraft(typeof(HeroRestorationPotion), "Magical", "Hero Restoration", 140.0, 200.0, typeof(HythlothKeeperBone), "Hytloth Keeper Bone", 5, "You do not have enough Hythloth Keeper bones to make that.");
			AddRes(index, typeof(DestardKeeperBone), "Destard Keeper Bone", 5, "You do not have enough Destard Keeper bones to make that.");
			AddRes(index, typeof(CovetousKeeperBone), "Covetous Keeper Bone", 5, "You do not have enough Covetous Keeper bones to make that.");
			AddRes(index, typeof(IceKeeperBone), "Ice Keeper Bone", 5, "You do not have enough Ice Keeper bones to make that.");
			AddRes(index, typeof(ShameKeeperBone), "Shame Keeper Bone", 5, "You do not have enough Shame Keeper bones to make that.");
			AddRes(index, typeof(Gold), "Gold", 20000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyGoldFlask), 1044529, 4, 500315);

			//Spelleable potions
			// todo make 5 potions for JumpPotion
			// ToDo change resources
			index = AddCraft(typeof(JumpPotion), "Magical", "Jump Potion", 180.0, 220.0, typeof(DragonsBlood), "Dragon Blood", 6, "You do not have enough dragon blood to make that.");
			AddRes(index, typeof(BronzeIngot), "Bronze Ingot", 10, "You do not have enough bronze ingots to make that.");
			AddRes(index, typeof(GoldIngot), "Gold Ingot", 10, "You do not have enough gold ingots to make that.");
			AddRes(index, typeof(Ruby), "Ruby", 1, "You do not have enough rubies to make that.");
			AddRes(index, typeof(Gold), "Gold", 2000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 3, 500315);

			index = AddCraft(typeof(MassPoisonPotion), "Magical", "Mass Poison Potion", 100.0, 150.0, typeof(Nightshade), 1044358, 100, 1044366);
			AddRes(index, typeof(BronzeIngot), "Bronze Ingot", 10, "You do not have enough bronze ingots to make that.");
			AddRes(index, typeof(Diamond), "Diamond", 1, "You do not have enough diamonds to make that.");
			AddRes(index, typeof(Gold), "Gold", 2000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 4, 500315);

			index = AddCraft(typeof(ParalyzePotion), "Magical", "Paralyze Potion", 100.0, 150.0, typeof(DragonBone), "Dragon Bone", 6, "You do not have enough dragon bones to make that.");
			AddRes(index, typeof(BronzeIngot), "Bronze Ingot", 10, "You do not have enough bronze ingots to make that.");
			AddRes(index, typeof(GoldIngot), "Gold Ingot", 10, "You do not have enough gold ingots to make that.");
			AddRes(index, typeof(Emerald), "Emerald", 1, "You do not have enough emeralds to make that.");
			AddRes(index, typeof(Gold), "Gold", 2000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 3, 500315);

			// ToDo change resources
			index = AddCraft(typeof(RevealPotion), "Magical", "Reveal Potion", 180.0, 220.0, typeof(DragonsBlood), "Dragon Blood", 6, "You do not have enough dragon blood to make that.");
			AddRes(index, typeof(BronzeIngot), "Bronze Ingot", 10, "You do not have enough bronze ingots to make that.");
			AddRes(index, typeof(GoldIngot), "Gold Ingot", 10, "You do not have enough gold ingots to make that.");
			AddRes(index, typeof(Ruby), "Ruby", 1, "You do not have enough rubies to make that.");
			AddRes(index, typeof(Gold), "Gold", 2000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 3, 500315);

			index = AddCraft(typeof(MagicReflectionPotion), "Magical", "Magic Reflect Potion", 100.0, 150.0, typeof(DragonsBlood), "Dragon Blood", 6, "You do not have enough dragon blood to make that.");
			AddRes(index, typeof(BronzeIngot), "Bronze Ingot", 10, "You do not have enough bronze ingots to make that.");
			AddRes(index, typeof(GoldIngot), "Gold Ingot", 10, "You do not have enough gold ingots to make that.");
			AddRes(index, typeof(Ruby), "Ruby", 1, "You do not have enough rubies to make that.");
			AddRes(index, typeof(Gold), "Gold", 2000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptyFlask), 1044529, 3, 500315);


			index = AddCraft(typeof(RepairElixir), "Magical", "Repair Elixir", 140.0, 180.0, typeof(DragonsBlood), "Dragon Blood", 6, "You do not have enough dragon blood to make that.");
			AddRes(index, typeof(BronzeIngot), "Bonus Point", 1, "You do not have enough Bonus points to make that.");
			AddRes(index, typeof(BronzeIngot), "Quest Point", 1, "You do not have enough Quest points to make that.");
			AddRes(index, typeof(BronzeIngot), "Event Point", 1, "You do not have enough Event points to make that.");
			AddRes(index, typeof(BronzeIngot), "Tournament Point", 1, "You do not have enough Tournament points to make that.");
			AddRes(index, typeof(Gold), "Gold", 500000, "You do not have enough gold to make that.");
			AddRes(index, typeof(BronzeIngot), "Elfian Elixir [+10]", 10, "You do not have enough Elfian Elixir to make that.");
			AddRes(index, typeof(SmallEmptyGoldFlask), 1044529, 1, 500315);


			index = AddCraft(typeof(NewbieRepairElixir), "Magical", "Repair Elixir", 160.0, 200.0, typeof(DragonsBlood), "Dragon Blood", 6, "You do not have enough dragon blood to make that.");
			AddRes(index, typeof(BronzeIngot), "Bonus Point", 1, "You do not have enough Bonus points to make that.");
			AddRes(index, typeof(BronzeIngot), "Quest Point", 1, "You do not have enough Quest points to make that.");
			AddRes(index, typeof(BronzeIngot), "Event Point", 1, "You do not have enough Event points to make that.");
			AddRes(index, typeof(BronzeIngot), "Tournament Point", 1, "You do not have enough Tournament points to make that.");
			AddRes(index, typeof(Gold), "Gold", 500000, "You do not have enough gold to make that.");
			AddRes(index, typeof(BronzeIngot), "Elfian Elixir [+10]", 10, "You do not have enough Elfian Elixir to make that.");
			AddRes(index, typeof(SmallEmptyGoldFlask), 1044529, 1, 500315);


			//ToDo x10 craft
			index = AddCraft(typeof(SmallBloodPotion), "Magical", "Small Blood Potion", 200.0, 250.0, typeof(DragonsBlood), "Dragon Blood", 1, "You do not have enough dragon blood to make that.");
			AddRes(index, typeof(DaemonBlood), "Daemon Blood", 1, "You do not have enough daemon blood to make that.");
			AddRes(index, typeof(TitansBlood), "Titans Blood", 1, "You do not have enough titans blood to make that.");
			AddRes(index, typeof(Gold), "Gold", 50000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptySilverFlask), 1044529, 1, 500315);

			index = AddCraft(typeof(BigBloodPotion), "Magical", "Small Blood Potion", 200.0, 250.0, typeof(SmallBloodPotion), "Small Blood Potion", 5, "You do not have enough small blood potions to make that.");
			AddRes(index, typeof(Gold), "Gold", 10000, "You do not have enough gold to make that.");
			AddRes(index, typeof(SmallEmptySilverFlask), 1044529, 1, 500315);

			// Berserkers Potion
			index = AddCraft(typeof(BerserkerPotion), "Magical", "Berserkers Potion", 200.0, 250.0, typeof(HythlothKeeperBone), "Hytloth Keeper Bone", 5, "You do not have enough Hythloth Keeper bones to make that.");
			AddRes(index, typeof(DestardKeeperBone), "Destard Keeper Bone", 1, "You do not have enough Destard Keeper bones to make that.");
			AddRes(index, typeof(CovetousKeeperBone), "Covetous Keeper Bone", 1, "You do not have enough Covetous Keeper bones to make that.");
			AddRes(index, typeof(IceKeeperBone), "Ice Keeper Bone", 1, "You do not have enough Ice Keeper bones to make that.");
			AddRes(index, typeof(ShameKeeperBone), "Shame Keeper Bone", 1, "You do not have enough Shame Keeper bones to make that.");

			AddRes(index, typeof(BronzeIngot), "RP Point", 1, "You do not have enough RP points to make that.");
			AddRes(index, typeof(BronzeIngot), "Tournament Point", 1, "You do not have enough Tournament points to make that.");
			AddRes(index, typeof(Gold), "Gold", 500000, "You do not have enough gold to make that.");
			AddRes(index, typeof(BronzeIngot), "Elfian Elixir [+10]", 10, "You do not have enough Elfian Elixir to make that.");
			AddRes(index, typeof(SmallEmptyGoldFlask), 1044529, 1, 500315);

			#endregion
		}
	}
}
