using Server.Items;
using Server.Targeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Custom.Alchemy_Potions
{
	public class RepairElixir : Item
	{
		int m_RepairPoints;

		[CommandProperty(AccessLevel.GameMaster)]
		public virtual int RepairPoints { get { return m_RepairPoints; } set { m_RepairPoints = value; } }

		[Constructable]
		public RepairElixir() : base(0x182B)
		{
			Name = "Repair Elixir";
			m_RepairPoints = 20;
		}

		public RepairElixir(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsChildOf(from.Backpack))
			{
				from.Target = new RepairTarget(this);
				from.SendMessage("Select item to repair!");
			}
			else
				from.SendMessage("Elixir should be in your backpack!");
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version

			writer.Write(m_RepairPoints);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			m_RepairPoints = reader.ReadInt();
		}

		private class RepairTarget : Target
		{
			RepairElixir m_Elixir;
			public RepairTarget(RepairElixir elixir) : base(3, false, TargetFlags.None)
			{
				m_Elixir = elixir;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Elixir.Deleted || !m_Elixir.IsChildOf(from))
					return;

				if (targeted is IDurability)
				{
					IDurability item = targeted as IDurability;

					if (item is Item && ((Item)item).LootType == LootType.Newbied || ((Item)item).LootType == LootType.Blessed)
					{
						from.SendMessage("Current repair elixir can't repair newbied items. Use 'Newbie Repair Elixir' to repair newbie items.");
						return;
					}

					if (item.HitPoints < item.MaxHitPoints)
					{
						item.HitPoints += m_Elixir.RepairPoints;
						m_Elixir.Delete();

						from.SendMessage("You have successfull repair your item on {0} hit points!", m_Elixir.RepairPoints);
					}
					else
						from.SendMessage("This item already has full durability hit points.");
				}
				else
					from.SendMessage("You can use repair elixir only on durable items.");
			}
		}
	}
}
