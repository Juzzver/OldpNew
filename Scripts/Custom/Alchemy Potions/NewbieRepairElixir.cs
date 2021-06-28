using Server.Items;
using Server.Targeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Items
{
	public class NewbieRepairElixir : RepairElixir
	{
		[Constructable]
		public NewbieRepairElixir() : base()
		{
			Name = "Newbie Repair Elixir";
			RepairPoints = 20;
		}

		public NewbieRepairElixir(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsChildOf(from.Backpack))
			{
				from.Target = new NewbieRepairTarget(this);
				from.SendMessage("Select newbie item to repair!");
			}
			else
				from.SendMessage("Elixir should be in your backpack!");
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

		private class NewbieRepairTarget : Target
		{
			NewbieRepairElixir m_Elixir;
			public NewbieRepairTarget(NewbieRepairElixir elixir) : base(3, false, TargetFlags.None)
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

					if (item is Item && ((Item)item).LootType != LootType.Newbied && ((Item)item).LootType != LootType.Blessed)
					{
						from.SendMessage("Current repair elixir can be used only for newbie items. Use 'Repair Elixir' to repair regular items.");
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
