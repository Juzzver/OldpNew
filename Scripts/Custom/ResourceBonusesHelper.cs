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
		public virtual double StealthDamageRate { get; set; }

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
					case CraftResource.None: return null;
					case CraftResource.Iron: return null;
					case CraftResource.Bronze:
						break;
					case CraftResource.Silver:
						break;
					case CraftResource.Stone:
						break;
					case CraftResource.Gypsum:
						break;
					case CraftResource.Copper:
						break;
					case CraftResource.Gold:
						break;
					case CraftResource.Titan:
						break;
					case CraftResource.Verite:
						break;
					case CraftResource.Valorite:
						break;
					case CraftResource.BlueRock:
						break;
					case CraftResource.Aqua:
						break;
					case CraftResource.Plazma:
						break;
					case CraftResource.Crystal:
						break;
					case CraftResource.Acid:
						break;
					case CraftResource.Plutonium:
						break;
					case CraftResource.BloodRock:
						break;
					case CraftResource.Glory:
						break;
					case CraftResource.Frost:
						break;
					case CraftResource.Meteor:
						break;
					case CraftResource.BlueSteel:
						break;
					case CraftResource.Iridium:
						break;
					case CraftResource.WhiteStone:
						break;
					case CraftResource.Diamond:
						break;
					case CraftResource.Mythril:
						break;
					case CraftResource.Shadow:
						break;
					case CraftResource.Legendary:
						break;
					case CraftResource.Lava:
						return new LavaArmorBonuses(res, type, level);
				}
			}

			return null;
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

					if (armor.Resource <= CraftResource.Iron ||  armor.Resource != (setItems[0] as BaseArmor).Resource)
						return CraftResource.None;
				}

				return (setItems[0] as BaseArmor).Resource; // return 1st piece of res that equals with other parts
			}
			return CraftResource.None;

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
