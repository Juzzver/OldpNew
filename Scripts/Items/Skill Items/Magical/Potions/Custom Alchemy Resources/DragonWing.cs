using System;
using Server.Items;

namespace Server.Items
{
	public class DragonWing : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public DragonWing() : this(1)
		{
		}

		[Constructable]
		public DragonWing(int amount) : base(3960)
		{
			Name = "Dragon Wing";
			Hue = 38;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public DragonWing(Serial serial) : base(serial)
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
	}
}
