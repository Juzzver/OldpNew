using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Items
{

	public class BluePickaxe : Pickaxe
	{
		[Constructable]
		public BluePickaxe()
		{
			Name = "Blue Pickaxe";
			Hue = 90;
			PickType = PickaxeType.Blue;
		}

		public BluePickaxe(Serial serial) : base(serial)
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

	public class RedPickaxe : Pickaxe
	{
		[Constructable]
		public RedPickaxe()
		{
			Name = "Red Pickaxe";
			Hue = 38;
			PickType = PickaxeType.Red;
		}

		public RedPickaxe(Serial serial) : base(serial)
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

	public class GreenPickaxe : Pickaxe
	{
		[Constructable]
		public GreenPickaxe()
		{
			Name = "Green Pickaxe";
			Hue = 68;
			PickType = PickaxeType.Green;
		}

		public GreenPickaxe(Serial serial) : base(serial)
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

	public class YellowPickaxe : Pickaxe
	{
		[Constructable]
		public YellowPickaxe()
		{
			Name = "Yellow Pickaxe";
			Hue = 53;
			PickType = PickaxeType.Yellow;
		}

		public YellowPickaxe(Serial serial) : base(serial)
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

	public class OrangePickaxe : Pickaxe
	{
		[Constructable]
		public OrangePickaxe() 
		{
			Name = "Orange Pickaxe";
			Hue = 43;
			PickType = PickaxeType.Orange;
		}

		public OrangePickaxe(Serial serial) : base(serial)
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

	public class WhitePickaxe : Pickaxe
	{
		[Constructable]
		public WhitePickaxe()
		{
			Name = "White Pickaxe";
			Hue = 1153;
			PickType = PickaxeType.White;
		}

		public WhitePickaxe(Serial serial) : base(serial)
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
