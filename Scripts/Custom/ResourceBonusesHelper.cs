using Server.Items;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class BaseArmorResourceBonus
	{
		public virtual int Level { get; set; }
		public virtual CraftResource Resource { get; set; }
		public virtual ArmorMaterialType Type { get; set; }

		public virtual int StrBonus { get; set; }
		public virtual int DexBonus { get; set; }
		public virtual int IntBonus { get; set; }

		public virtual int HitsBonus { get; set; }
		public virtual int StamBonus { get; set; }
		public virtual int ManaBonus { get; set; }

		public virtual int HPRegenBonus { get; set; }
		public virtual int StamRegenBonus { get; set; }
		public virtual int ManaRegenBonus { get; set; }

		public virtual double AbsorbDamageRate { get; set; }
		public virtual double AbsorbMagicDamageRate { get; set; }
		public virtual double ResistFireRate { get; set; }
		public virtual double ResistColdRate { get; set; }
		public virtual double ResistPoisonRate { get; set; }
		public virtual double ResistEnergyRate { get; set; }

		public virtual double AbsorbFireRate { get; set; }
		public virtual double AbsorbColdRate { get; set; }
		public virtual double AbsorbPoisonRate { get; set; }
		public virtual double AbsorbEnergyRate { get; set; }

		public virtual double ResistMageryRate { get; set; }

		public virtual double IncreaseDamageRate { get; set; }
		public virtual double IncreaseFireRate { get; set; }
		public virtual double IncreaseColdRate { get; set; }
		public virtual double IncreasePoisonRate { get; set; }
		public virtual double IncreaseEnergyRate { get; set; }
		public virtual double StealthBonusDamageRate { get; set; }

		public virtual double CriticalDamageRate { get; set; }

		public virtual double CastSpeedRate { get; set; }
		public virtual double MusicanshipBonusRate { get; set; }

		public virtual double LightningDamageBonusRate { get; set; }

		public virtual int HealingBonus { get; set; }

		public virtual double IncreaseCrossbowDamageRate { get; set; }

		public virtual double ResistStunningEffect { get; set; }

		public virtual double FlameStrikeImmunity { get; set; }

		public virtual double BlockRate { get; set; }

		public virtual double IncreaseMountPropsRate { get; set; }

		public virtual bool CanRunInStealth { get; set; }

		// earth effect ressistance



		public virtual Dictionary<SkillName, double> SkillBonuses { get; set; }

		public virtual double ParalyzeFieldImmunityRate { get; set; }
		public virtual bool DisableParalyzeFieldDelay { get; set; }


		public virtual double FatiqueRate { get; set; }
		public virtual double FatiqueResistanceRate { get; set; }

		public virtual double CookingEatBonusRate { get; set; }

		public virtual double MagicReflectionRate { get; set; }
		public virtual double PhysReflectionRate { get; set; }

		public virtual double GetBonusFromFullSet(Mobile m)
		{
			return 0;
		}

		public virtual int GetBonusFromPieceOfSet(Mobile m)
		{
			return 0;
		}

		public static BaseArmorResourceBonus GetSetInstance(Mobile m)
		{
			List<Item> setItems = m.Items.FindAll(x => x is BaseArmor &&
			x.Layer == Layer.Helm ||
			x.Layer == Layer.Neck ||
			x.Layer == Layer.Arms ||
			x.Layer == Layer.Gloves ||
			x.Layer == Layer.InnerTorso ||
			x.Layer == Layer.Pants
			);


			if (IsFullArmorSet(setItems))
			{
				BaseArmor setPiece = setItems[0] as BaseArmor;
				int level = setPiece.ArmorLevel;
				CraftResource res = setPiece.Resource;
				ArmorMaterialType type = setPiece.MaterialType;

				switch (GetSetResource(setItems))
				{
					case CraftResource.Titan:
						return new TitanArmorBonuses(res, type, level);
					case CraftResource.Verite:
						return new VeriteArmorBonuses(res, type, level);
					case CraftResource.Valorite:
						return new ValoriteArmorBonuses(res, type, level);
					case CraftResource.BlueRock:
						return new BlueRockArmorBonuses(res, type, level);
					case CraftResource.Aqua:
						return new AquaArmorBonuses(res, type, level);
					case CraftResource.Plazma:
						return new PlazmaArmorBonuses(res, type, level);
					case CraftResource.Crystal:
						return new CrystalArmorBonuses(res, type, level);
					case CraftResource.Acid:
						return new AcidArmorBonuses(res, type, level);
					case CraftResource.Plutonium:
						return new PlutoniumArmorBonuses(res, type, level);
					case CraftResource.BloodRock:
						return new BloodRockArmorBonuses(res, type, level);
					case CraftResource.Glory:
						return new GloryArmorBonuses(res, type, level);
					case CraftResource.Frost:
						return new FrostArmorBonuses(res, type, level);
					case CraftResource.Meteor:
						return new MeteorArmorBonuses(res, type, level);
					case CraftResource.BlueSteel:
						return new BlueSteelArmorBonuses(res, type, level);
					case CraftResource.Iridium:
						return new IridiumArmorBonuses(res, type, level);
					case CraftResource.WhiteStone:
						return new WhiteStoneArmorBonuses(res, type, level);
					case CraftResource.Diamond:
						return new DiamondArmorBonuses(res, type, level);
					case CraftResource.Mythril:
						return new MythrilArmorBonuses(res, type, level);
					case CraftResource.Shadow:
						return new ShadowArmorBonuses(res, type, level);
					//case CraftResource.Legendary:
					//	return new LegendaryArmorBonuses(res, type, level);
					case CraftResource.Lava:
						return new LavaArmorBonuses(res, type, level);
				}
			}

			return null;
		}

		public static bool IsItemPieceOfSet(Item item = null)
		{
			return item.Layer == Layer.Helm ||
			item.Layer == Layer.Neck ||
			item.Layer == Layer.Arms ||
			item.Layer == Layer.Gloves ||
			item.Layer == Layer.InnerTorso ||
			item.Layer == Layer.Pants;
		}

		public static bool IsFullArmorSet(List<Item> setItems)
		{
			var setItemList = setItems.FindAll(x => x is BaseArmor &&
			x.Layer == Layer.Helm ||
			x.Layer == Layer.Neck ||
			x.Layer == Layer.Arms ||
			x.Layer == Layer.Gloves ||
			x.Layer == Layer.InnerTorso ||
			x.Layer == Layer.Pants
			);

			return setItemList.Count == 6
			&& IsSetHasSameType(setItemList)
			&& IsSetHasSameLevel(setItemList);
		}

		public static bool IsSetHasSameType(List<Item> setItems)
		{
			for (int i = 0; i < setItems.Count; i++)
			{
				if (setItems[i] is BaseArmor)
				{
					BaseArmor armor = setItems[i] as BaseArmor;

					if (armor.MaterialType != (setItems[0] as BaseArmor).MaterialType) // all parts must have equal types, like plate, chain etc
						return false;
				}
			}

			return true;
		}

		public static bool IsSetHasSameLevel(List<Item> setItems)
		{
			for (int i = 0; i < setItems.Count; i++)
			{
				if (setItems[i] is BaseArmor)
				{
					BaseArmor armor = setItems[i] as BaseArmor;

					if (armor.ArmorLevel != (setItems[0] as BaseArmor).ArmorLevel) // all parts must have the same level
						return false;
				}
			}

			return true;
		}

		public static CraftResource GetSetResource(List<Item> setItems)
		{
			//var setItems = m.Items.FindAll(x => x is BaseArmor &&
			//x.Layer == Layer.Helm &&
			//x.Layer == Layer.Neck &&
			//x.Layer == Layer.Arms &&
			//x.Layer == Layer.Gloves &&
			//x.Layer == Layer.InnerTorso &&
			//x.Layer == Layer.Pants
			//);

			if (setItems != null && setItems.Count == 6) // full set
			{
				for (int i = 0; i < setItems.Count; i++)
				{
					BaseArmor armor = setItems[i] as BaseArmor;

					if (armor.Resource <= CraftResource.Iron || armor.Resource != (setItems[0] as BaseArmor).Resource)
						return CraftResource.None;
				}

				return (setItems[0] as BaseArmor).Resource; // return 1st piece of res that equals with other parts
			}
			return CraftResource.None;

		}

		public virtual void OnItemAdded(Mobile m)
		{
			OnItemRemoved(m);

			if (SkillBonuses != null && SkillBonuses.Count > 0)
			{
				foreach (KeyValuePair<SkillName, double> kvp in SkillBonuses)
				{
					SkillMod sk = new DefaultSkillMod(kvp.Key, true, kvp.Value);
					sk.ObeyCap = false;
					m.AddSkillMod(sk);
				}
			}
		}

		public virtual void OnItemRemoved(Mobile m)
		{
			if (SkillBonuses != null && SkillBonuses.Count > 0)
			{
				List<SkillMod> modsToRemove = new List<SkillMod>();

				foreach (var mod in m.SkillMods)
				{
					if (SkillBonuses.ContainsKey(mod.Skill))
						modsToRemove.Add(mod);
				}

				foreach (var mod in modsToRemove)
				{
					if (m.SkillMods.Contains(mod))
						m.RemoveSkillMod(mod);
				}
			}
		}
	}

	public class LavaArmorBonuses : BaseArmorResourceBonus
	{
		public LavaArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 260;
								case 2: return 80;
								//case 3: return 240;
								case 4: return 100;
								case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 240;
								case 2: return 70;
								//case 3: return 240;
								case 4: return 100;
								case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 300;
								case 2: return 100;
								//case 3: return 240;
								case 4: return 100;
								case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override int IntBonus
		{
			get
			{
				switch (Level)
				{
					case 2: return 70;
				}

				return 0;
			}
		}

		public override bool DisableParalyzeFieldDelay { get { return Level == 2; } }
		public override double CastSpeedRate { get { return Level == 1 ? 0.3 : 0; } }
	}

	public class TitanArmorBonuses : BaseArmorResourceBonus
	{
		public TitanArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override double AbsorbDamageRate
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						return 0.15;
					case ArmorMaterialType.Chainmail:
						return 0.15;
					case ArmorMaterialType.Plate:
						return 0.2; // 20%
				}

				return 0;
			}
		}
	}

	public class ValoriteArmorBonuses : BaseArmorResourceBonus
	{
		public ValoriteArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override Dictionary<SkillName, double> SkillBonuses
		{
			get
			{
				var skillTable = new Dictionary<SkillName, double>();
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							skillTable.Add(SkillName.Archery, 12);
							skillTable.Add(SkillName.Tactics, 12);
							skillTable.Add(SkillName.Swords, 12);
							skillTable.Add(SkillName.Parry, 12);
							return skillTable;
						}

					case ArmorMaterialType.Chainmail:
						{
							skillTable.Add(SkillName.Archery, 10);
							skillTable.Add(SkillName.Tactics, 10);
							skillTable.Add(SkillName.Swords, 10);
							skillTable.Add(SkillName.Parry, 10);
							return skillTable;
						}
					case ArmorMaterialType.Plate:
						{
							skillTable.Add(SkillName.Archery, 15);
							skillTable.Add(SkillName.Tactics, 15);
							skillTable.Add(SkillName.Swords, 15);
							skillTable.Add(SkillName.Parry, 15);
							return skillTable;
						}
				}

				return skillTable;
			}
		}
	}

	public class VeriteArmorBonuses : BaseArmorResourceBonus
	{
		public VeriteArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override double FatiqueRate => 2;
	}

	public class BlueRockArmorBonuses : BaseArmorResourceBonus
	{
		public BlueRockArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override Dictionary<SkillName, double> SkillBonuses
		{
			get
			{
				var skillTable = new Dictionary<SkillName, double>();

				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							skillTable.Add(SkillName.Macing, 35);
							skillTable.Add(SkillName.Tactics, 35);
							skillTable.Add(SkillName.Parry, 15);
							return skillTable;
						}

					case ArmorMaterialType.Chainmail:
						{
							skillTable.Add(SkillName.Macing, 30);
							skillTable.Add(SkillName.Tactics, 30);
							skillTable.Add(SkillName.Parry, 12);
							return skillTable;
						}
					case ArmorMaterialType.Plate:
						{
							skillTable.Add(SkillName.Macing, 40);
							skillTable.Add(SkillName.Tactics, 40);
							skillTable.Add(SkillName.Parry, 20);
							return skillTable;
						}
				}

				return skillTable;
			}
		}
	}

	public class AquaArmorBonuses : BaseArmorResourceBonus
	{
		public AquaArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override double AbsorbFireRate => 0.5;
	}

	public class PlazmaArmorBonuses : BaseArmorResourceBonus
	{
		public PlazmaArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override double ParalyzeFieldImmunityRate => 1;
	}

	public class CrystalArmorBonuses : BaseArmorResourceBonus
	{
		public CrystalArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override double AbsorbPoisonRate => 80;
	}


	public class AcidArmorBonuses : BaseArmorResourceBonus
	{
		public AcidArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		// ToDo стихи на выбор должны быть.
		public override double IncreaseColdRate => 0.3;
		public override double IncreaseEnergyRate => 0.3;
		public override double IncreasePoisonRate => 0.3;
		public override double IncreaseFireRate => 0.3;
		public override double IncreaseDamageRate => 0.3;

		//Каждая часть регенит +1 маны
	}

	public class PlutoniumArmorBonuses : BaseArmorResourceBonus
	{
		public PlutoniumArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 80;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 70;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 100;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double IncreaseDamageRate => 0.15;
		public override double CastSpeedRate { get { return Level == 1 ? 0.3 : 0; } }
	}

	public class BloodRockArmorBonuses : BaseArmorResourceBonus
	{
		public BloodRockArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 45;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 40;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 50;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double CastSpeedRate { get { return Level == 1 ? 0.2 : 0; } }
	}

	public class GloryArmorBonuses : BaseArmorResourceBonus
	{
		public GloryArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 80;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 60;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 100;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double AbsorbDamageRate => 0.25;
	}

	public class FrostArmorBonuses : BaseArmorResourceBonus
	{
		public FrostArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 90;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 80;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 100;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double AbsorbFireRate => 0.7;
	}


	//todo regens
	public class MeteorArmorBonuses : BaseArmorResourceBonus
	{
		public MeteorArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 135;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 120;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 150;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double AbsorbFireRate => 0.7;
	}

	public class BlueSteelArmorBonuses : BaseArmorResourceBonus
	{
		public BlueSteelArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 90;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 80;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 100;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override Dictionary<SkillName, double> SkillBonuses
		{
			get
			{
				var skillTable = new Dictionary<SkillName, double>();
				skillTable.Add(SkillName.Healing, 80);
				return skillTable;
			}
		}
	}
	//todo musicanship delay
	public class IridiumArmorBonuses : BaseArmorResourceBonus
	{
		public IridiumArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 130;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 120;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 150;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double MusicanshipBonusRate => 0.5;
	}

	public class WhiteStoneArmorBonuses : BaseArmorResourceBonus
	{
		public WhiteStoneArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 260;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 220;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 300;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}
		public override double MagicReflectionRate => 0.3;
	}

	public class DiamondArmorBonuses : BaseArmorResourceBonus
	{
		public DiamondArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 250;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 220;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 300;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}

		// резистит в ближ врага.
		public override double PhysReflectionRate => 0.2;
	}

	public class MythrilArmorBonuses : BaseArmorResourceBonus
	{
		public MythrilArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 250;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 200;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 300;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}

		public override double ResistMageryRate => 0.5;
		public override double AbsorbMagicDamageRate => 0.2;


	}

	public class ShadowArmorBonuses : BaseArmorResourceBonus
	{
		public ShadowArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		public override int StrBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 180;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 160;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 200;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}

		public override int DexBonus
		{
			get
			{
				switch (Type)
				{
					case ArmorMaterialType.Ringmail:
						{
							switch (Level)
							{
								case 1: return 70;
								//case 2: return 80;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 80;
								default: return 0;
							}
						}
					case ArmorMaterialType.Chainmail:
						{
							switch (Level)
							{
								case 1: return 60;
								//case 2: return 70;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 70;
								default: return 0;
							}
						}
					case ArmorMaterialType.Plate:
						{
							switch (Level)
							{
								case 1: return 80;
								//case 2: return 100;
								////case 3: return 240;
								//case 4: return 100;
								//case 5: return 100;
								default: return 0;
							}
						}
				}
				return 0;

			}
		}

		public override Dictionary<SkillName, double> SkillBonuses
		{
			get
			{
				var skillTable = new Dictionary<SkillName, double>();

				skillTable.Add(SkillName.Stealth, 60);

				return skillTable;
			}
		}

		public override double StealthBonusDamageRate => 0.3;


	}

	public class LegendaryArmorBonuses : BaseArmorResourceBonus
	{
		public LegendaryArmorBonuses(CraftResource res, ArmorMaterialType type, int level)
		{
			Resource = res;
			Type = type;
			Level = level;
		}

		//public override int StrBonus
		//{
		//	get
		//	{
		//		switch (Type)
		//		{
		//			case ArmorMaterialType.Ringmail:
		//				{
		//					switch (Level)
		//					{
		//						case 1: return 180;
		//						//case 2: return 80;
		//						////case 3: return 240;
		//						//case 4: return 100;
		//						//case 5: return 80;
		//						default: return 0;
		//					}
		//				}
		//			case ArmorMaterialType.Chainmail:
		//				{
		//					switch (Level)
		//					{
		//						case 1: return 160;
		//						//case 2: return 70;
		//						////case 3: return 240;
		//						//case 4: return 100;
		//						//case 5: return 70;
		//						default: return 0;
		//					}
		//				}
		//			case ArmorMaterialType.Plate:
		//				{
		//					switch (Level)
		//					{
		//						case 1: return 200;
		//						//case 2: return 100;
		//						////case 3: return 240;
		//						//case 4: return 100;
		//						//case 5: return 100;
		//						default: return 0;
		//					}
		//				}
		//		}
		//		return 0;

		//	}
		//}

		//public override int DexBonus
		//{
		//	get
		//	{
		//		switch (Type)
		//		{
		//			case ArmorMaterialType.Ringmail:
		//				{
		//					switch (Level)
		//					{
		//						case 1: return 70;
		//						//case 2: return 80;
		//						////case 3: return 240;
		//						//case 4: return 100;
		//						//case 5: return 80;
		//						default: return 0;
		//					}
		//				}
		//			case ArmorMaterialType.Chainmail:
		//				{
		//					switch (Level)
		//					{
		//						case 1: return 60;
		//						//case 2: return 70;
		//						////case 3: return 240;
		//						//case 4: return 100;
		//						//case 5: return 70;
		//						default: return 0;
		//					}
		//				}
		//			case ArmorMaterialType.Plate:
		//				{
		//					switch (Level)
		//					{
		//						case 1: return 80;
		//						//case 2: return 100;
		//						////case 3: return 240;
		//						//case 4: return 100;
		//						//case 5: return 100;
		//						default: return 0;
		//					}
		//				}
		//		}
		//		return 0;

		//	}
		//}

		//public override Dictionary<SkillName, double> SkillBonuses
		//{
		//	get
		//	{
		//		var skillTable = new Dictionary<SkillName, double>();

		//		skillTable.Add(SkillName.Stealth, 60);

		//		return skillTable;
		//	}
		//}



	}





	public class ResourcesBonusHelper
	{


		public static int GetManaRegBonus(Mobile m)
		{
			return m.Items.FindAll(x => x is BaseArmor && ((BaseArmor)x).Resource == CraftResource.Silver).Count;
		}

		public static int GetHPRegBonus(Mobile m)
		{
			return m.Items.FindAll(x => x is BaseArmor && ((BaseArmor)x).Resource == CraftResource.Gold).Count;
		}

		//public double DecreaseDamageRate(Mobile m)
		//{


		//}
	}
}
