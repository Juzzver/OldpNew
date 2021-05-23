using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Items
{

	public class StrongAxe : Hatchet
	{
		[Constructable]
		public StrongAxe() : base()
		{
			Name = "Strong Axe";
			Hue = 90;
			ToolType = AxeType.Strong;
		}

		public StrongAxe(Serial serial) : base(serial)
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
			ShowUsesRemaining = true;
		}
	}

	public class HardAxe : Hatchet
	{
		[Constructable]
		public HardAxe()
		{
			Name = "Hard Axe";
			Hue = 38;
			ToolType = AxeType.Hard;
		}

		public HardAxe(Serial serial) : base(serial)
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
			ShowUsesRemaining = true;
		}
	}

	public class MythrilAxe : Hatchet
	{
		[Constructable]
		public MythrilAxe()
		{
			Name = "Mythril Axe";
			Hue = 1152;
			ToolType = AxeType.Mythril;
		}

		public MythrilAxe(Serial serial) : base(serial)
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
			ShowUsesRemaining = true;
		}
	}

	public class LegendaryAxe : Hatchet
	{
		[Constructable]
		public LegendaryAxe()
		{
			Name = "Legendary Axe";
			Hue =1174;
			ToolType = AxeType.Legendary;
		}

		public LegendaryAxe(Serial serial) : base(serial)
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
			ShowUsesRemaining = true;
		}
	}
}
