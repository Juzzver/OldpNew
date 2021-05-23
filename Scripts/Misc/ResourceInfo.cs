using System;
using System.Collections.Generic;

namespace Server.Items
{
	public enum CraftResource
	{
		None = 0,
		Iron = 1,
		Bronze,
		Silver,
		Stone,
		Gypsum,
		Copper,
		Gold,

		Titan,
		Verite,
		Valorite,
		BlueRock,
		Aqua,
		Plazma,
		Crystal,
		Acid,

		Plutonium,
		BloodRock,
		Glory,
		Frost,
		Meteor,
		BlueSteel,
		Iridium,

		WhiteStone,
		Diamond,
		Mythril,
		Shadow,
		Legendary,
		Lava,

		RegularLeather = 101,
		SpinedLeather,
		HornedLeather,
		BarbedLeather,

		RedScales = 201,
		YellowScales,
		BlackScales,
		GreenScales,
		WhiteScales,
		BlueScales,

		RegularWood = 301,
		WillowWood,
		AspenWood,
		ElvenWood,
		DendroidWood,
		ScorpionWood,
		FrozenWood,
		HamelionWood,
		IceWood,
		RoseWood,
		DeadWood,
		HolyWood,
		ArianWood,
		MillenniumWood,
		MysticWood,
		TeriumWood,
		AncientWood,
		LifeWood,
		ChaosWood,
		LegendaryBlackOakWood

	}

	public enum CraftResourceType
	{
		None,
		Metal,
		Leather,
		Scales,
		Wood
	}

	public class CraftAttributeInfo
	{
		private int m_WeaponFireDamage;
		private int m_WeaponColdDamage;
		private int m_WeaponPoisonDamage;
		private int m_WeaponEnergyDamage;
		private int m_WeaponChaosDamage;
		private int m_WeaponDirectDamage;
		private int m_WeaponDurability;
		private int m_WeaponLuck;
		private int m_WeaponGoldIncrease;
		private int m_WeaponLowerRequirements;

		private int m_ArmorPhysicalResist;
		private int m_ArmorFireResist;
		private int m_ArmorColdResist;
		private int m_ArmorPoisonResist;
		private int m_ArmorEnergyResist;
		private int m_ArmorDurability;
		private int m_ArmorLuck;
		private int m_ArmorGoldIncrease;
		private int m_ArmorLowerRequirements;

		private int m_RunicMinAttributes;
		private int m_RunicMaxAttributes;
		private int m_RunicMinIntensity;
		private int m_RunicMaxIntensity;

		public int WeaponFireDamage { get { return m_WeaponFireDamage; } set { m_WeaponFireDamage = value; } }
		public int WeaponColdDamage { get { return m_WeaponColdDamage; } set { m_WeaponColdDamage = value; } }
		public int WeaponPoisonDamage { get { return m_WeaponPoisonDamage; } set { m_WeaponPoisonDamage = value; } }
		public int WeaponEnergyDamage { get { return m_WeaponEnergyDamage; } set { m_WeaponEnergyDamage = value; } }
		public int WeaponChaosDamage { get { return m_WeaponChaosDamage; } set { m_WeaponChaosDamage = value; } }
		public int WeaponDirectDamage { get { return m_WeaponDirectDamage; } set { m_WeaponDirectDamage = value; } }
		public int WeaponDurability { get { return m_WeaponDurability; } set { m_WeaponDurability = value; } }
		public int WeaponLuck { get { return m_WeaponLuck; } set { m_WeaponLuck = value; } }
		public int WeaponGoldIncrease { get { return m_WeaponGoldIncrease; } set { m_WeaponGoldIncrease = value; } }
		public int WeaponLowerRequirements { get { return m_WeaponLowerRequirements; } set { m_WeaponLowerRequirements = value; } }

		public int ArmorPhysicalResist { get { return m_ArmorPhysicalResist; } set { m_ArmorPhysicalResist = value; } }
		public int ArmorFireResist { get { return m_ArmorFireResist; } set { m_ArmorFireResist = value; } }
		public int ArmorColdResist { get { return m_ArmorColdResist; } set { m_ArmorColdResist = value; } }
		public int ArmorPoisonResist { get { return m_ArmorPoisonResist; } set { m_ArmorPoisonResist = value; } }
		public int ArmorEnergyResist { get { return m_ArmorEnergyResist; } set { m_ArmorEnergyResist = value; } }
		public int ArmorDurability { get { return m_ArmorDurability; } set { m_ArmorDurability = value; } }
		public int ArmorLuck { get { return m_ArmorLuck; } set { m_ArmorLuck = value; } }
		public int ArmorGoldIncrease { get { return m_ArmorGoldIncrease; } set { m_ArmorGoldIncrease = value; } }
		public int ArmorLowerRequirements { get { return m_ArmorLowerRequirements; } set { m_ArmorLowerRequirements = value; } }

		public int RunicMinAttributes { get { return m_RunicMinAttributes; } set { m_RunicMinAttributes = value; } }
		public int RunicMaxAttributes { get { return m_RunicMaxAttributes; } set { m_RunicMaxAttributes = value; } }
		public int RunicMinIntensity { get { return m_RunicMinIntensity; } set { m_RunicMinIntensity = value; } }
		public int RunicMaxIntensity { get { return m_RunicMaxIntensity; } set { m_RunicMaxIntensity = value; } }

		public CraftAttributeInfo()
		{
		}

		public static readonly CraftAttributeInfo Blank;
		public static readonly CraftAttributeInfo Bronze, Silver, Stone, Gypsum, Copper, Gold, Titan,
		Valorite, Verite, BlueRock, Aqua, Plazma, Crystal, Acid, Plutonium, BloodRock, Glory, Frost,
		Meteor, BlueSteel, Iridium, WhiteStone, Diamond, Mythril, Shadow, Legendary, Lava;
		public static readonly CraftAttributeInfo Spined, Horned, Barbed;
		public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales;
		public static readonly CraftAttributeInfo WillowWood, AspenWood, ElvenWood, DendroidWood, ScorpionWood, FrozenWood,
		HamelionWood, IceWood, RoseWood, DeadWood, HolyWood, ArianWood, MillenniumWood,
		MysticWood, TeriumWood, AncientWood, LifeWood, ChaosWood, LegendaryBlackOakWood;

		static CraftAttributeInfo()
		{
			Blank = new CraftAttributeInfo();

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

			bronze.ArmorPhysicalResist = 6;
			bronze.ArmorDurability = 50;
			bronze.ArmorLowerRequirements = 20;
			bronze.WeaponDurability = 100;
			bronze.WeaponLowerRequirements = 50;
			bronze.RunicMinAttributes = 1;
			bronze.RunicMaxAttributes = 2;
			if (Core.ML)
			{
				bronze.RunicMinIntensity = 40;
				bronze.RunicMaxIntensity = 100;
			}
			else
			{
				bronze.RunicMinIntensity = 10;
				bronze.RunicMaxIntensity = 35;
			}

			CraftAttributeInfo silver = Silver = new CraftAttributeInfo();

			silver.ArmorPhysicalResist = 2;
			silver.ArmorFireResist = 1;
			silver.ArmorEnergyResist = 5;
			silver.ArmorDurability = 100;
			silver.WeaponColdDamage = 20;
			silver.WeaponDurability = 50;
			silver.RunicMinAttributes = 2;
			silver.RunicMaxAttributes = 2;
			if (Core.ML)
			{
				silver.RunicMinIntensity = 45;
				silver.RunicMaxIntensity = 100;
			}
			else
			{
				silver.RunicMinIntensity = 20;
				silver.RunicMaxIntensity = 45;
			}

			CraftAttributeInfo stone = Stone = new CraftAttributeInfo();

			stone.ArmorPhysicalResist = 1;
			stone.ArmorFireResist = 1;
			stone.ArmorPoisonResist = 5;
			stone.ArmorEnergyResist = 2;
			stone.WeaponPoisonDamage = 10;
			stone.WeaponEnergyDamage = 20;
			stone.RunicMinAttributes = 2;
			stone.RunicMaxAttributes = 3;
			if (Core.ML)
			{
				stone.RunicMinIntensity = 50;
				stone.RunicMaxIntensity = 100;
			}
			else
			{
				stone.RunicMinIntensity = 25;
				stone.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo gypsum = Gypsum = new CraftAttributeInfo();

			gypsum.ArmorPhysicalResist = 1;
			gypsum.ArmorFireResist = 1;
			gypsum.ArmorPoisonResist = 5;
			gypsum.ArmorEnergyResist = 2;
			gypsum.WeaponPoisonDamage = 10;
			gypsum.WeaponEnergyDamage = 20;
			gypsum.RunicMinAttributes = 2;
			gypsum.RunicMaxAttributes = 3;
			if (Core.ML)
			{
				gypsum.RunicMinIntensity = 50;
				gypsum.RunicMaxIntensity = 100;
			}
			else
			{
				gypsum.RunicMinIntensity = 25;
				gypsum.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

			copper.ArmorPhysicalResist = 1;
			copper.ArmorFireResist = 1;
			copper.ArmorPoisonResist = 5;
			copper.ArmorEnergyResist = 2;
			copper.WeaponPoisonDamage = 10;
			copper.WeaponEnergyDamage = 20;
			copper.RunicMinAttributes = 2;
			copper.RunicMaxAttributes = 3;
			if (Core.ML)
			{
				copper.RunicMinIntensity = 50;
				copper.RunicMaxIntensity = 100;
			}
			else
			{
				copper.RunicMinIntensity = 25;
				copper.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo gold = Gold = new CraftAttributeInfo();

			gold.ArmorPhysicalResist = 1;
			gold.ArmorFireResist = 1;
			gold.ArmorColdResist = 2;
			gold.ArmorEnergyResist = 2;
			gold.ArmorLuck = 40;
			gold.ArmorLowerRequirements = 30;
			gold.WeaponLuck = 40;
			gold.WeaponLowerRequirements = 50;
			gold.RunicMinAttributes = 3;
			gold.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				gold.RunicMinIntensity = 60;
				gold.RunicMaxIntensity = 100;
			}
			else
			{
				gold.RunicMinIntensity = 35;
				gold.RunicMaxIntensity = 75;
			}
			//------------------------------------------------

			CraftAttributeInfo titan = Titan = new CraftAttributeInfo();

			titan.ArmorPhysicalResist = 3;
			titan.ArmorColdResist = 5;
			titan.ArmorPoisonResist = 1;
			titan.ArmorEnergyResist = 1;
			titan.WeaponFireDamage = 40;
			titan.RunicMinAttributes = 3;
			titan.RunicMaxAttributes = 3;
			if (Core.ML)
			{
				titan.RunicMinIntensity = 55;
				titan.RunicMaxIntensity = 100;
			}
			else
			{
				titan.RunicMinIntensity = 30;
				titan.RunicMaxIntensity = 65;
			}

			CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

			valorite.ArmorPhysicalResist = 4;
			valorite.ArmorColdResist = 3;
			valorite.ArmorPoisonResist = 3;
			valorite.ArmorEnergyResist = 3;
			valorite.ArmorDurability = 50;
			valorite.WeaponFireDamage = 10;
			valorite.WeaponColdDamage = 20;
			valorite.WeaponPoisonDamage = 10;
			valorite.WeaponEnergyDamage = 20;
			valorite.RunicMinAttributes = 5;
			valorite.RunicMaxAttributes = 5;
			if (Core.ML)
			{
				valorite.RunicMinIntensity = 85;
				valorite.RunicMaxIntensity = 100;
			}
			else
			{
				valorite.RunicMinIntensity = 50;
				valorite.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

			verite.ArmorPhysicalResist = 3;
			verite.ArmorFireResist = 3;
			verite.ArmorColdResist = 2;
			verite.ArmorPoisonResist = 3;
			verite.ArmorEnergyResist = 1;
			verite.WeaponPoisonDamage = 40;
			verite.WeaponEnergyDamage = 20;
			verite.RunicMinAttributes = 4;
			verite.RunicMaxAttributes = 5;
			if (Core.ML)
			{
				verite.RunicMinIntensity = 70;
				verite.RunicMaxIntensity = 100;
			}
			else
			{
				verite.RunicMinIntensity = 45;
				verite.RunicMaxIntensity = 90;
			}

			CraftAttributeInfo blueRock = BlueRock = new CraftAttributeInfo();

			blueRock.ArmorPhysicalResist = 3;
			blueRock.ArmorColdResist = 5;
			blueRock.ArmorPoisonResist = 1;
			blueRock.ArmorEnergyResist = 1;
			blueRock.WeaponFireDamage = 40;
			blueRock.RunicMinAttributes = 3;
			blueRock.RunicMaxAttributes = 3;
			if (Core.ML)
			{
				blueRock.RunicMinIntensity = 55;
				blueRock.RunicMaxIntensity = 100;
			}
			else
			{
				blueRock.RunicMinIntensity = 30;
				blueRock.RunicMaxIntensity = 65;
			}

			CraftAttributeInfo aqua = Aqua = new CraftAttributeInfo();

			aqua.ArmorPhysicalResist = 2;
			aqua.ArmorFireResist = 3;
			aqua.ArmorColdResist = 2;
			aqua.ArmorPoisonResist = 2;
			aqua.ArmorEnergyResist = 2;
			aqua.WeaponColdDamage = 30;
			aqua.WeaponEnergyDamage = 20;
			aqua.RunicMinAttributes = 4;
			aqua.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				aqua.RunicMinIntensity = 65;
				aqua.RunicMaxIntensity = 100;
			}
			else
			{
				aqua.RunicMinIntensity = 40;
				aqua.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo plazma = Plazma = new CraftAttributeInfo();

			plazma.ArmorPhysicalResist = 2;
			plazma.ArmorFireResist = 3;
			plazma.ArmorColdResist = 2;
			plazma.ArmorPoisonResist = 2;
			plazma.ArmorEnergyResist = 2;
			plazma.WeaponColdDamage = 30;
			plazma.WeaponEnergyDamage = 20;
			plazma.RunicMinAttributes = 4;
			plazma.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				plazma.RunicMinIntensity = 65;
				plazma.RunicMaxIntensity = 100;
			}
			else
			{
				plazma.RunicMinIntensity = 40;
				plazma.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo crystal = Crystal = new CraftAttributeInfo();

			crystal.ArmorPhysicalResist = 2;
			crystal.ArmorFireResist = 3;
			crystal.ArmorColdResist = 2;
			crystal.ArmorPoisonResist = 2;
			crystal.ArmorEnergyResist = 2;
			crystal.WeaponColdDamage = 30;
			crystal.WeaponEnergyDamage = 20;
			crystal.RunicMinAttributes = 4;
			crystal.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				crystal.RunicMinIntensity = 65;
				crystal.RunicMaxIntensity = 100;
			}
			else
			{
				crystal.RunicMinIntensity = 40;
				crystal.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo acid = Acid = new CraftAttributeInfo();

			acid.ArmorPhysicalResist = 2;
			acid.ArmorFireResist = 3;
			acid.ArmorColdResist = 2;
			acid.ArmorPoisonResist = 2;
			acid.ArmorEnergyResist = 2;
			acid.WeaponColdDamage = 30;
			acid.WeaponEnergyDamage = 20;
			acid.RunicMinAttributes = 4;
			acid.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				acid.RunicMinIntensity = 65;
				acid.RunicMaxIntensity = 100;
			}
			else
			{
				acid.RunicMinIntensity = 40;
				acid.RunicMaxIntensity = 80;
			}

			//-------------------------------------


			CraftAttributeInfo plutonium = Plutonium = new CraftAttributeInfo();

			plutonium.ArmorPhysicalResist = 2;
			plutonium.ArmorFireResist = 3;
			plutonium.ArmorColdResist = 2;
			plutonium.ArmorPoisonResist = 2;
			plutonium.ArmorEnergyResist = 2;
			plutonium.WeaponColdDamage = 30;
			plutonium.WeaponEnergyDamage = 20;
			plutonium.RunicMinAttributes = 4;
			plutonium.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				plutonium.RunicMinIntensity = 65;
				plutonium.RunicMaxIntensity = 100;
			}
			else
			{
				plutonium.RunicMinIntensity = 40;
				plutonium.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo bloodRock = BloodRock = new CraftAttributeInfo();

			bloodRock.ArmorPhysicalResist = 2;
			bloodRock.ArmorFireResist = 3;
			bloodRock.ArmorColdResist = 2;
			bloodRock.ArmorPoisonResist = 2;
			bloodRock.ArmorEnergyResist = 2;
			bloodRock.WeaponColdDamage = 30;
			bloodRock.WeaponEnergyDamage = 20;
			bloodRock.RunicMinAttributes = 4;
			bloodRock.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				bloodRock.RunicMinIntensity = 65;
				bloodRock.RunicMaxIntensity = 100;
			}
			else
			{
				bloodRock.RunicMinIntensity = 40;
				bloodRock.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo glory = Glory = new CraftAttributeInfo();

			glory.ArmorPhysicalResist = 2;
			glory.ArmorFireResist = 3;
			glory.ArmorColdResist = 2;
			glory.ArmorPoisonResist = 2;
			glory.ArmorEnergyResist = 2;
			glory.WeaponColdDamage = 30;
			glory.WeaponEnergyDamage = 20;
			glory.RunicMinAttributes = 4;
			glory.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				glory.RunicMinIntensity = 65;
				glory.RunicMaxIntensity = 100;
			}
			else
			{
				glory.RunicMinIntensity = 40;
				glory.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo frost = Frost = new CraftAttributeInfo();

			frost.ArmorPhysicalResist = 2;
			frost.ArmorFireResist = 3;
			frost.ArmorColdResist = 2;
			frost.ArmorPoisonResist = 2;
			frost.ArmorEnergyResist = 2;
			frost.WeaponColdDamage = 30;
			frost.WeaponEnergyDamage = 20;
			frost.RunicMinAttributes = 4;
			frost.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				frost.RunicMinIntensity = 65;
				frost.RunicMaxIntensity = 100;
			}
			else
			{
				frost.RunicMinIntensity = 40;
				frost.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo meteor = Meteor = new CraftAttributeInfo();

			meteor.ArmorPhysicalResist = 2;
			meteor.ArmorFireResist = 3;
			meteor.ArmorColdResist = 2;
			meteor.ArmorPoisonResist = 2;
			meteor.ArmorEnergyResist = 2;
			meteor.WeaponColdDamage = 30;
			meteor.WeaponEnergyDamage = 20;
			meteor.RunicMinAttributes = 4;
			meteor.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				meteor.RunicMinIntensity = 65;
				meteor.RunicMaxIntensity = 100;
			}
			else
			{
				meteor.RunicMinIntensity = 40;
				meteor.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo blueSteel = BlueSteel = new CraftAttributeInfo();

			blueSteel.ArmorPhysicalResist = 2;
			blueSteel.ArmorFireResist = 3;
			blueSteel.ArmorColdResist = 2;
			blueSteel.ArmorPoisonResist = 2;
			blueSteel.ArmorEnergyResist = 2;
			blueSteel.WeaponColdDamage = 30;
			blueSteel.WeaponEnergyDamage = 20;
			blueSteel.RunicMinAttributes = 4;
			blueSteel.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				blueSteel.RunicMinIntensity = 65;
				blueSteel.RunicMaxIntensity = 100;
			}
			else
			{
				blueSteel.RunicMinIntensity = 40;
				blueSteel.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo iridium = Iridium = new CraftAttributeInfo();

			iridium.ArmorPhysicalResist = 2;
			iridium.ArmorFireResist = 3;
			iridium.ArmorColdResist = 2;
			iridium.ArmorPoisonResist = 2;
			iridium.ArmorEnergyResist = 2;
			iridium.WeaponColdDamage = 30;
			iridium.WeaponEnergyDamage = 20;
			iridium.RunicMinAttributes = 4;
			iridium.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				iridium.RunicMinIntensity = 65;
				iridium.RunicMaxIntensity = 100;
			}
			else
			{
				iridium.RunicMinIntensity = 40;
				iridium.RunicMaxIntensity = 80;
			}

			//------------------------------------

			CraftAttributeInfo whiteStone = WhiteStone = new CraftAttributeInfo();

			whiteStone.ArmorPhysicalResist = 2;
			whiteStone.ArmorFireResist = 3;
			whiteStone.ArmorColdResist = 2;
			whiteStone.ArmorPoisonResist = 2;
			whiteStone.ArmorEnergyResist = 2;
			whiteStone.WeaponColdDamage = 30;
			whiteStone.WeaponEnergyDamage = 20;
			whiteStone.RunicMinAttributes = 4;
			whiteStone.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				whiteStone.RunicMinIntensity = 65;
				whiteStone.RunicMaxIntensity = 100;
			}
			else
			{
				whiteStone.RunicMinIntensity = 40;
				whiteStone.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo diamond = Diamond = new CraftAttributeInfo();

			diamond.ArmorPhysicalResist = 2;
			diamond.ArmorFireResist = 3;
			diamond.ArmorColdResist = 2;
			diamond.ArmorPoisonResist = 2;
			diamond.ArmorEnergyResist = 2;
			diamond.WeaponColdDamage = 30;
			diamond.WeaponEnergyDamage = 20;
			diamond.RunicMinAttributes = 4;
			diamond.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				diamond.RunicMinIntensity = 65;
				diamond.RunicMaxIntensity = 100;
			}
			else
			{
				diamond.RunicMinIntensity = 40;
				diamond.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo mythril = Mythril = new CraftAttributeInfo();

			mythril.ArmorPhysicalResist = 2;
			mythril.ArmorFireResist = 3;
			mythril.ArmorColdResist = 2;
			mythril.ArmorPoisonResist = 2;
			mythril.ArmorEnergyResist = 2;
			mythril.WeaponColdDamage = 30;
			mythril.WeaponEnergyDamage = 20;
			mythril.RunicMinAttributes = 4;
			mythril.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				mythril.RunicMinIntensity = 65;
				mythril.RunicMaxIntensity = 100;
			}
			else
			{
				mythril.RunicMinIntensity = 40;
				mythril.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo shadow = Shadow = new CraftAttributeInfo();

			shadow.ArmorPhysicalResist = 2;
			shadow.ArmorFireResist = 3;
			shadow.ArmorColdResist = 2;
			shadow.ArmorPoisonResist = 2;
			shadow.ArmorEnergyResist = 2;
			shadow.WeaponColdDamage = 30;
			shadow.WeaponEnergyDamage = 20;
			shadow.RunicMinAttributes = 4;
			shadow.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				shadow.RunicMinIntensity = 65;
				shadow.RunicMaxIntensity = 100;
			}
			else
			{
				shadow.RunicMinIntensity = 40;
				shadow.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo legendary = Legendary = new CraftAttributeInfo();

			legendary.ArmorPhysicalResist = 2;
			legendary.ArmorFireResist = 3;
			legendary.ArmorColdResist = 2;
			legendary.ArmorPoisonResist = 2;
			legendary.ArmorEnergyResist = 2;
			legendary.WeaponColdDamage = 30;
			legendary.WeaponEnergyDamage = 20;
			legendary.RunicMinAttributes = 4;
			legendary.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				legendary.RunicMinIntensity = 65;
				legendary.RunicMaxIntensity = 100;
			}
			else
			{
				legendary.RunicMinIntensity = 40;
				legendary.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo lava = Lava = new CraftAttributeInfo();

			lava.ArmorPhysicalResist = 2;
			lava.ArmorFireResist = 3;
			lava.ArmorColdResist = 2;
			lava.ArmorPoisonResist = 2;
			lava.ArmorEnergyResist = 2;
			lava.WeaponColdDamage = 30;
			lava.WeaponEnergyDamage = 20;
			lava.RunicMinAttributes = 4;
			lava.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				lava.RunicMinIntensity = 65;
				lava.RunicMaxIntensity = 100;
			}
			else
			{
				lava.RunicMinIntensity = 40;
				lava.RunicMaxIntensity = 80;
			}


			CraftAttributeInfo spined = Spined = new CraftAttributeInfo();

			spined.ArmorPhysicalResist = 5;
			spined.ArmorLuck = 40;
			spined.RunicMinAttributes = 1;
			spined.RunicMaxAttributes = 3;
			if (Core.ML)
			{
				spined.RunicMinIntensity = 40;
				spined.RunicMaxIntensity = 100;
			}
			else
			{
				spined.RunicMinIntensity = 20;
				spined.RunicMaxIntensity = 40;
			}

			CraftAttributeInfo horned = Horned = new CraftAttributeInfo();

			horned.ArmorPhysicalResist = 2;
			horned.ArmorFireResist = 3;
			horned.ArmorColdResist = 2;
			horned.ArmorPoisonResist = 2;
			horned.ArmorEnergyResist = 2;
			horned.RunicMinAttributes = 3;
			horned.RunicMaxAttributes = 4;
			if (Core.ML)
			{
				horned.RunicMinIntensity = 45;
				horned.RunicMaxIntensity = 100;
			}
			else
			{
				horned.RunicMinIntensity = 30;
				horned.RunicMaxIntensity = 70;
			}

			CraftAttributeInfo barbed = Barbed = new CraftAttributeInfo();

			barbed.ArmorPhysicalResist = 2;
			barbed.ArmorFireResist = 1;
			barbed.ArmorColdResist = 2;
			barbed.ArmorPoisonResist = 3;
			barbed.ArmorEnergyResist = 4;
			barbed.RunicMinAttributes = 4;
			barbed.RunicMaxAttributes = 5;
			if (Core.ML)
			{
				barbed.RunicMinIntensity = 50;
				barbed.RunicMaxIntensity = 100;
			}
			else
			{
				barbed.RunicMinIntensity = 40;
				barbed.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo red = RedScales = new CraftAttributeInfo();

			red.ArmorFireResist = 10;
			red.ArmorColdResist = -3;

			CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

			yellow.ArmorPhysicalResist = -3;
			yellow.ArmorLuck = 20;

			CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

			black.ArmorPhysicalResist = 10;
			black.ArmorEnergyResist = -3;

			CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

			green.ArmorFireResist = -3;
			green.ArmorPoisonResist = 10;

			CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

			white.ArmorPhysicalResist = -3;
			white.ArmorColdResist = 10;

			CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

			blue.ArmorPoisonResist = -3;
			blue.ArmorEnergyResist = 10;

			//public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;

			//CraftAttributeInfo oak = OakWood = new CraftAttributeInfo();

			//CraftAttributeInfo ash = AshWood = new CraftAttributeInfo();

			//CraftAttributeInfo yew = YewWood = new CraftAttributeInfo();

			//CraftAttributeInfo heart = Heartwood = new CraftAttributeInfo();

			//CraftAttributeInfo blood = Bloodwood = new CraftAttributeInfo();

			//CraftAttributeInfo frostwood = Frostwood = new CraftAttributeInfo();
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue { get { return m_Hue; } }
		public int Number { get { return m_Number; } }
		public string Name { get { return m_Name; } }
		public CraftAttributeInfo AttributeInfo { get { return m_AttributeInfo; } }
		public CraftResource Resource { get { return m_Resource; } }
		public Type[] ResourceTypes { get { return m_ResourceTypes; } }

		public CraftResourceInfo(int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes)
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
			m_AttributeInfo = attributeInfo;
			m_Resource = resource;
			m_ResourceTypes = resourceTypes;

			for (int i = 0; i < resourceTypes.Length; ++i)
				CraftResources.RegisterType(resourceTypes[i], resource);
		}
	}

	public class CraftResources
	{
		private static CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1053109, "Iron",          CraftAttributeInfo.Blank,       CraftResource.Iron,             typeof( IronIngot ),        typeof( IronOre ),          typeof( Granite ) ),
				new CraftResourceInfo( 0x972, 1053105, "Bronze",        CraftAttributeInfo.Bronze,      CraftResource.Bronze,           typeof( BronzeIngot ),      typeof( BronzeOre ),        typeof( BronzeGranite ) ),
				new CraftResourceInfo( 1154, 0, "Silver",   CraftAttributeInfo.Silver,  CraftResource.Silver,       typeof( SilverIngot ),  typeof(SilverOre ),    typeof( SilverGranite ) ),
				new CraftResourceInfo( 0x03E3, 0, "Stone",   CraftAttributeInfo.Stone,  CraftResource.Stone,       typeof( StoneIngot ),  typeof( StoneOre ),    typeof( StoneGranite ) ),
				new CraftResourceInfo( 2965, 0, "Gypsum",        CraftAttributeInfo.Gypsum,      CraftResource.Gypsum,           typeof( GypsumIngot ),      typeof( GypsumOre ),        typeof( GypsumGranite ) ),
				new CraftResourceInfo( 0x96D, 1053106, "Copper",        CraftAttributeInfo.Copper,      CraftResource.Copper,           typeof( CopperIngot ),      typeof( CopperOre ),        typeof( CopperGranite ) ),
				new CraftResourceInfo( 0x8A5, 1053104, "Gold",          CraftAttributeInfo.Gold,      CraftResource.Gold,             typeof( GoldIngot ),        typeof( GoldOre ),          typeof( GoldGranite ) ),
				new CraftResourceInfo( 2498, 0, "Titan",       CraftAttributeInfo.Titan,     CraftResource.Titan,          typeof( TitanIngot ),     typeof( TitanOre ),       typeof( TitanGranite ) ),
				new CraftResourceInfo( 0x89F, 1053102, "Verite",        CraftAttributeInfo.Verite,      CraftResource.Verite,           typeof( VeriteIngot ),      typeof( VeriteOre ),        typeof( VeriteGranite ) ),
				new CraftResourceInfo( 0x8AB, 1053101, "Valorite",      CraftAttributeInfo.Valorite,    CraftResource.Valorite,         typeof( ValoriteIngot ),    typeof( ValoriteOre ),      typeof( ValoriteGranite ) ),

			 
				new CraftResourceInfo( 2747, 0, "Blue Rock",   CraftAttributeInfo.BlueRock,  CraftResource.BlueRock,       typeof( BlueRockIngot ),  typeof( BlueRockOre ),    typeof( BlueRockGranite ) ),
				new CraftResourceInfo( 2729, 0, "Aqua",   CraftAttributeInfo.Aqua,  CraftResource.Aqua,       typeof( AquaIngot ),  typeof( AquaOre ),    typeof( AquaGranite ) ),
				
				new CraftResourceInfo( 1287, 0, "Plazma",        CraftAttributeInfo.Plazma,      CraftResource.Plazma,           typeof( PlazmaIngot ),      typeof( PlazmaOre ),        typeof( PlazmaGranite ) ),
				new CraftResourceInfo( 1195, 0, "Crystal",          CraftAttributeInfo.Crystal,      CraftResource.Crystal,             typeof( CrystalIngot ),        typeof( CrystalOre ),          typeof( CrystalGranite ) ),
				new CraftResourceInfo( 1969, 0, "Acid",        CraftAttributeInfo.Acid,      CraftResource.Acid,           typeof( AcidIngot ),      typeof( AcidOre ),        typeof( AcidGranite ) ),
				new CraftResourceInfo( 1161, 0, "Plutonium",       CraftAttributeInfo.Plutonium,     CraftResource.Plutonium,          typeof( PlutoniumIngot ),     typeof( PlutoniumOre ),       typeof( PlutoniumGranite ) ),
				new CraftResourceInfo( 1920, 0, "Blood Rock",      CraftAttributeInfo.BloodRock,    CraftResource.BloodRock,         typeof( BloodRockIngot ),    typeof( BloodRockOre ),      typeof( BloodRockGranite ) ),

				new CraftResourceInfo( 1288, 0, "Glory",		    CraftAttributeInfo.Glory,  CraftResource.Glory,       typeof( GloryIngot ),  typeof( GloryOre ),    typeof( GloryGranite ) ),
				new CraftResourceInfo( 2741, 0, "Frost",   CraftAttributeInfo.Frost,  CraftResource.Frost,       typeof( FrostIngot ),  typeof( FrostOre ),    typeof( FrostGranite ) ),
				new CraftResourceInfo( 2071, 0, "Meteor",        CraftAttributeInfo.Meteor,      CraftResource.Meteor,           typeof( MeteorIngot ),      typeof( MeteorOre ),        typeof( MeteorGranite ) ),
				new CraftResourceInfo( 2746, 0, "Blue Steel",        CraftAttributeInfo.BlueSteel,      CraftResource.BlueSteel,           typeof( BlueSteelIngot ),      typeof( BlueSteelOre ),        typeof( BlueSteelGranite ) ),
				new CraftResourceInfo( 2728, 0, "Iridium",          CraftAttributeInfo.Iridium,      CraftResource.Iridium,             typeof( IridiumIngot ),        typeof( IridiumOre ),          typeof( IridiumGranite ) ),
				new CraftResourceInfo( 1153, 0, "White Stone",       CraftAttributeInfo.WhiteStone,     CraftResource.WhiteStone,          typeof( WhiteStoneIngot ),     typeof( WhiteStoneOre ),       typeof( WhiteStoneGranite ) ),
				new CraftResourceInfo( 2066, 0, "Diamond",        CraftAttributeInfo.Diamond,      CraftResource.Diamond,           typeof( DiamondIngot ),      typeof( DiamondOre ),        typeof( DiamondGranite ) ),
				new CraftResourceInfo( 2738, 0, "Mythril",      CraftAttributeInfo.Mythril,    CraftResource.Mythril,         typeof( MythrilIngot ),    typeof( MythrilOre ),      typeof( MythrilGranite ) ),

				new CraftResourceInfo( 1910, 0, "Shadow",        CraftAttributeInfo.Shadow,      CraftResource.Shadow,           typeof( ShadowIngot ),      typeof( ShadowOre ),        typeof( ShadowGranite ) ),
				new CraftResourceInfo( 2070, 0, "Legendary",        CraftAttributeInfo.Legendary,      CraftResource.Legendary,           typeof( LegendaryIngot ),      typeof( LegendaryOre ),        typeof( LegendaryGranite ) ),
				new CraftResourceInfo( 2736, 0, "Lava",          CraftAttributeInfo.Lava,      CraftResource.Lava,             typeof( LavaIngot ),        typeof( LavaOre ),          typeof( LavaGranite ) ),
				
			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x66D, 1053129, "Red Scales",    CraftAttributeInfo.RedScales,       CraftResource.RedScales,        typeof( RedScales ) ),
				new CraftResourceInfo( 0x8A8, 1053130, "Yellow Scales", CraftAttributeInfo.YellowScales,    CraftResource.YellowScales,     typeof( YellowScales ) ),
				new CraftResourceInfo( 0x455, 1053131, "Black Scales",  CraftAttributeInfo.BlackScales,     CraftResource.BlackScales,      typeof( BlackScales ) ),
				new CraftResourceInfo( 0x851, 1053132, "Green Scales",  CraftAttributeInfo.GreenScales,     CraftResource.GreenScales,      typeof( GreenScales ) ),
				new CraftResourceInfo( 0x8FD, 1053133, "White Scales",  CraftAttributeInfo.WhiteScales,     CraftResource.WhiteScales,      typeof( WhiteScales ) ),
				new CraftResourceInfo( 0x8B0, 1053134, "Blue Scales",   CraftAttributeInfo.BlueScales,      CraftResource.BlueScales,       typeof( BlueScales ) )
			};

		private static CraftResourceInfo[] m_LeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",        CraftAttributeInfo.Blank,       CraftResource.RegularLeather,   typeof( Leather ),          typeof( Hides ) ),
				new CraftResourceInfo( 0x283, 1049354, "Spined",        CraftAttributeInfo.Spined,      CraftResource.SpinedLeather,    typeof( SpinedLeather ),    typeof( SpinedHides ) ),
				new CraftResourceInfo( 0x227, 1049355, "Horned",        CraftAttributeInfo.Horned,      CraftResource.HornedLeather,    typeof( HornedLeather ),    typeof( HornedHides ) ),
				new CraftResourceInfo( 0x1C1, 1049356, "Barbed",        CraftAttributeInfo.Barbed,      CraftResource.BarbedLeather,    typeof( BarbedLeather ),    typeof( BarbedHides ) )
			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 1049353, "Normal",        CraftAttributeInfo.Blank,       CraftResource.RegularLeather,   typeof( Leather ),          typeof( Hides ) ),
				new CraftResourceInfo( 0x8AC, 1049354, "Spined",        CraftAttributeInfo.Spined,      CraftResource.SpinedLeather,    typeof( SpinedLeather ),    typeof( SpinedHides ) ),
				new CraftResourceInfo( 0x845, 1049355, "Horned",        CraftAttributeInfo.Horned,      CraftResource.HornedLeather,    typeof( HornedLeather ),    typeof( HornedHides ) ),
				new CraftResourceInfo( 0x851, 1049356, "Barbed",        CraftAttributeInfo.Barbed,      CraftResource.BarbedLeather,    typeof( BarbedLeather ),    typeof( BarbedHides ) ),
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 1287, 0, "Normal",        CraftAttributeInfo.Blank,       CraftResource.RegularWood,  typeof( Log ),          typeof( Board ) ),
				new CraftResourceInfo( 1195, 0, "Willow",           CraftAttributeInfo.WillowWood,     CraftResource.WillowWood,      typeof( Log ),       typeof( Board ) ),
				new CraftResourceInfo( 1969, 0, "Aspen",           CraftAttributeInfo.AspenWood,     CraftResource.AspenWood,      typeof( AspenLog ),       typeof( AspenBoard ) ),
				new CraftResourceInfo( 1161, 0, "Elven",           CraftAttributeInfo.ElvenWood,     CraftResource.ElvenWood,      typeof( ElvenLog ),       typeof( ElvenBoard ) ),
				new CraftResourceInfo( 1920, 0, "Dendroid",     CraftAttributeInfo.DendroidWood,   CraftResource.DendroidWood,    typeof( DendroidLog ), typeof( DendroidBoard ) ),
				new CraftResourceInfo( 1288, 0, "Scorpion",     CraftAttributeInfo.ScorpionWood,   CraftResource.ScorpionWood,    typeof( ScorpionLog ), typeof( ScorpionBoard ) ),
				new CraftResourceInfo( 2741, 0, "Frozen",     CraftAttributeInfo.FrozenWood,   CraftResource.FrozenWood,    typeof( FrozenLog ), typeof( FrozenBoard ) ),
				new CraftResourceInfo( 2071, 0, "Hamelion",           CraftAttributeInfo.HamelionWood,     CraftResource.HamelionWood,      typeof( HamelionLog ),       typeof( HamelionBoard ) ),
				new CraftResourceInfo( 2746, 0, "Ice",           CraftAttributeInfo.IceWood,     CraftResource.IceWood,      typeof( IceLog ),       typeof( IceBoard ) ),
				new CraftResourceInfo( 2728, 0, "Rose",           CraftAttributeInfo.RoseWood,     CraftResource.RoseWood,      typeof( RoseLog ),       typeof( RoseBoard ) ),
				new CraftResourceInfo( 1153, 0, "Dead",           CraftAttributeInfo.DeadWood,     CraftResource.DeadWood,      typeof( DeadLog ),       typeof( DeadBoard ) ),
				new CraftResourceInfo( 2066, 0, "Holy",           CraftAttributeInfo.HolyWood,     CraftResource.HolyWood,      typeof( HolyLog ),       typeof( HolyBoard ) ),               
				new CraftResourceInfo( 2738, 0, "Arian",           CraftAttributeInfo.ArianWood,     CraftResource.ArianWood,      typeof( ArianLog ),       typeof( ArianBoard ) ),
				new CraftResourceInfo( 1154, 0, "Millennium",           CraftAttributeInfo.MillenniumWood,     CraftResource.MillenniumWood,      typeof( MillenniumLog ),       typeof( MillenniumBoard ) ),				
				new CraftResourceInfo( 2965, 0, "Mystic",           CraftAttributeInfo.MysticWood,     CraftResource.MysticWood,      typeof( MysticLog ),       typeof( MysticBoard ) ),
				new CraftResourceInfo( 1910, 0, "Terium",           CraftAttributeInfo.TeriumWood,     CraftResource.TeriumWood,      typeof( TeriumLog ),       typeof( TeriumBoard ) ),				
				new CraftResourceInfo( 2070, 0, "Ancient",           CraftAttributeInfo.AncientWood,     CraftResource.AncientWood,      typeof( AncientLog ),       typeof( AncientBoard ) ),
				new CraftResourceInfo( 2736, 0, "Life",           CraftAttributeInfo.LifeWood,     CraftResource.LifeWood,      typeof( LifeLog ),       typeof( LifeBoard ) ),				
				new CraftResourceInfo( 2747, 0, "Chaos",           CraftAttributeInfo.ChaosWood,     CraftResource.ChaosWood,      typeof( ChaosLog ),       typeof( ChaosBoard ) ),
				new CraftResourceInfo( 2729, 0, "Legendary Black Oak",           CraftAttributeInfo.LegendaryBlackOakWood,     CraftResource.LegendaryBlackOakWood,      typeof( LegendaryBlackOakLog ),       typeof( LegendaryBlackOakBoard ) ),				
			};

		/// <summary>
		/// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
		/// </summary>
		public static bool IsStandard(CraftResource resource)
		{
			return (resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood);
		}

		private static Dictionary<Type, CraftResource> m_TypeTable;

		/// <summary>
		/// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="CraftResources.GetFromType"/>
		/// </summary>
		public static void RegisterType(Type resourceType, CraftResource resource)
		{
			if (m_TypeTable == null)
				m_TypeTable = new Dictionary<Type, CraftResource>();

			m_TypeTable[resourceType] = resource;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
		/// </summary>
		public static CraftResource GetFromType(Type resourceType)
		{
			if (m_TypeTable == null)
				return CraftResource.None;

			CraftResource res;

			if (!m_TypeTable.TryGetValue(resourceType, out res))
				return CraftResource.None;

			return res;
		}

		public static CraftResource GetResourceFromItem(Item item)
		{
			if (item is BaseArmor)
				return (item as BaseArmor).Resource;
			else if (item is BaseWeapon)
				return (item as BaseWeapon).Resource;
			else if (item is BaseClothing)
				return (item as BaseClothing).Resource;
			else if (item is BaseJewel)
				return (item as BaseJewel).Resource;

			return CraftResource.None;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
		/// </summary>
		public static CraftResourceInfo GetInfo(CraftResource resource)
		{
			CraftResourceInfo[] list = null;

			switch (GetType(resource))
			{
				case CraftResourceType.Metal: list = m_MetalInfo; break;
				case CraftResourceType.Leather: list = Core.AOS ? m_AOSLeatherInfo : m_LeatherInfo; break;
				case CraftResourceType.Scales: list = m_ScaleInfo; break;
				case CraftResourceType.Wood: list = m_WoodInfo; break;
			}

			if (list != null)
			{
				int index = GetIndex(resource);

				if (index >= 0 && index < list.Length)
					return list[index];
			}

			return null;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
		/// </summary>
		public static CraftResourceType GetType(CraftResource resource)
		{
			if (resource >= CraftResource.Iron && resource <= CraftResource.Lava)
				return CraftResourceType.Metal;

			if (resource >= CraftResource.RegularLeather && resource <= CraftResource.BarbedLeather)
				return CraftResourceType.Leather;

			if (resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales)
				return CraftResourceType.Scales;

			if (resource >= CraftResource.RegularWood && resource <= CraftResource.LegendaryBlackOakWood)
				return CraftResourceType.Wood;

			return CraftResourceType.None;
		}

		/// <summary>
		/// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
		/// </summary>
		public static CraftResource GetStart(CraftResource resource)
		{
			switch (GetType(resource))
			{
				case CraftResourceType.Metal: return CraftResource.Iron;
				case CraftResourceType.Leather: return CraftResource.RegularLeather;
				case CraftResourceType.Scales: return CraftResource.RedScales;
				case CraftResourceType.Wood: return CraftResource.RegularWood;
			}

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
		/// </summary>
		public static int GetIndex(CraftResource resource)
		{
			CraftResource start = GetStart(resource);

			if (start == CraftResource.None)
				return 0;

			return (int)(resource - start);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetLocalizationNumber(CraftResource resource)
		{
			CraftResourceInfo info = GetInfo(resource);

			return (info == null ? 0 : info.Number);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetHue(CraftResource resource)
		{
			CraftResourceInfo info = GetInfo(resource);

			return (info == null ? 0 : info.Hue);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
		/// </summary>
		public static string GetName(CraftResource resource)
		{
			CraftResourceInfo info = GetInfo(resource);

			return (info == null ? String.Empty : info.Name);
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo(OreInfo info)
		{
			if (info.Name.IndexOf("Spined") >= 0)
				return CraftResource.SpinedLeather;
			else if (info.Name.IndexOf("Horned") >= 0)
				return CraftResource.HornedLeather;
			else if (info.Name.IndexOf("Barbed") >= 0)
				return CraftResource.BarbedLeather;
			else if (info.Name.IndexOf("Leather") >= 0)
				return CraftResource.RegularLeather;

			if (info.Level == 0)
				return CraftResource.Iron;
			else if (info.Level == 1)
				return CraftResource.Bronze;
			else if (info.Level == 2)
				return CraftResource.Silver;
			else if (info.Level == 3)
				return CraftResource.Stone;
			else if (info.Level == 4)
				return CraftResource.Gypsum;
			else if (info.Level == 5)
				return CraftResource.Copper;
			else if (info.Level == 6)
				return CraftResource.Gold;
			else if (info.Level == 7)
				return CraftResource.Titan;
			else if (info.Level == 8)
				return CraftResource.Valorite;
			else if (info.Level == 9)
				return CraftResource.Verite;
			else if (info.Level == 10)
				return CraftResource.BlueRock;
			else if (info.Level == 11)
				return CraftResource.Aqua;
			else if (info.Level == 12)
				return CraftResource.Plazma;
			else if (info.Level == 13)
				return CraftResource.Crystal;
			else if (info.Level == 14)
				return CraftResource.Acid;
			else if (info.Level == 15)
				return CraftResource.Plutonium;
			else if (info.Level == 16)
				return CraftResource.BloodRock;
			else if (info.Level == 17)
				return CraftResource.Glory;
			else if (info.Level == 18)
				return CraftResource.Frost;
			else if (info.Level == 19)
				return CraftResource.Meteor;
			else if (info.Level == 20)
				return CraftResource.BlueSteel;
			else if (info.Level == 21)
				return CraftResource.Iridium;
			else if (info.Level == 22)
				return CraftResource.WhiteStone;
			else if (info.Level == 23)
				return CraftResource.Diamond;
			else if (info.Level == 24)
				return CraftResource.Mythril;
			else if (info.Level == 25)
				return CraftResource.Shadow;
			else if (info.Level == 26)
				return CraftResource.Legendary;
			else if (info.Level == 27)
				return CraftResource.Lava;

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
		/// </summary>
		public static CraftResource GetFromOreInfo(OreInfo info, ArmorMaterialType material)
		{
			if (material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather || material == ArmorMaterialType.Spined ||
				material == ArmorMaterialType.Horned || material == ArmorMaterialType.Barbed)
			{
				if (info.Level == 0)
					return CraftResource.RegularLeather;
				else if (info.Level == 1)
					return CraftResource.SpinedLeather;
				else if (info.Level == 2)
					return CraftResource.HornedLeather;
				else if (info.Level == 3)
					return CraftResource.BarbedLeather;

				return CraftResource.None;
			}

			return GetFromOreInfo(info);
		}
	}

	// NOTE: This class is only for compatability with very old RunUO versions.
	// No changes to it should be required for custom resources.
	public class OreInfo
	{
		public static readonly OreInfo Iron = new OreInfo(0, 0x000, "Iron");
		public static readonly OreInfo Bronze = new OreInfo(1, 0x973, "Bronze");
		public static readonly OreInfo Silver = new OreInfo(2, 0x966, "Silver");
		public static readonly OreInfo Stone = new OreInfo(3, 0x96D, "Stone");
		public static readonly OreInfo Gypsum = new OreInfo(4, 0x972, "Gypsum");
		public static readonly OreInfo Copper = new OreInfo(5, 0x8A5, "Copper");
		public static readonly OreInfo Gold = new OreInfo(6, 0x979, "Gold");
		public static readonly OreInfo Titan = new OreInfo(7, 0x89F, "Titan");
		public static readonly OreInfo Valorite = new OreInfo(8, 0x8AB, "Valorite");
		public static readonly OreInfo Verite = new OreInfo(9, 0x8AB, "Verite");
		public static readonly OreInfo BlueRock = new OreInfo(10, 0x8AB, "Blue Rock");
		public static readonly OreInfo Aqua = new OreInfo(11, 0x8AB, "Aqua");
		public static readonly OreInfo Plazma = new OreInfo(12, 0x8AB, "Plazma");
		public static readonly OreInfo Crystal = new OreInfo(13, 0x8AB, "Crystal");
		public static readonly OreInfo Acid = new OreInfo(14, 0x8AB, "Acid");
		public static readonly OreInfo Plutonium = new OreInfo(15, 0x8AB, "Plutonium");
		public static readonly OreInfo BloodRock = new OreInfo(16, 0x8AB, "Blood Rock");
		public static readonly OreInfo Glory = new OreInfo(17, 0x8AB, "Glory");
		public static readonly OreInfo Frost = new OreInfo(18, 0x8AB, "Frost");
		public static readonly OreInfo Meteor = new OreInfo(19, 0x8AB, "Meteor");
		public static readonly OreInfo BlueSteel = new OreInfo(20, 0x8AB, "Blue Steel");
		public static readonly OreInfo Iridium = new OreInfo(21, 0x8AB, "Iridium");
		public static readonly OreInfo WhiteStone = new OreInfo(22, 0x8AB, "White Stone");
		public static readonly OreInfo Diamond = new OreInfo(23, 0x8AB, "Diamond");
		public static readonly OreInfo Mythril = new OreInfo(24, 0x8AB, "Mythril");
		public static readonly OreInfo Shadow = new OreInfo(25, 0x8AB, "Shadow");
		public static readonly OreInfo Legendary = new OreInfo(26, 0x8AB, "Valorite");
		public static readonly OreInfo Lava = new OreInfo(27, 0x8AB, "Lava");

		private int m_Level;
		private int m_Hue;
		private string m_Name;

		public OreInfo(int level, int hue, string name)
		{
			m_Level = level;
			m_Hue = hue;
			m_Name = name;
		}

		public int Level
		{
			get
			{
				return m_Level;
			}
		}

		public int Hue
		{
			get
			{
				return m_Hue;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}
	}
}
