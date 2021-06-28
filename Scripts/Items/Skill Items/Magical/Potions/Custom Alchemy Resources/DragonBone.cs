using System;
using Server.Items;

namespace Server.Items
{
	public class DragonBone : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public DragonBone() : this(1)
		{
		}

		[Constructable]
		public DragonBone(int amount) : base(0xf7e)
		{
			Name = "Dragon Bone";
			Hue = 38;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public DragonBone(Serial serial) : base(serial)
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
