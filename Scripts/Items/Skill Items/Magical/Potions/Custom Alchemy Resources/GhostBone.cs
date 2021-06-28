using System;
using Server.Items;

namespace Server.Items
{
	public class GhostBone : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public GhostBone() : this(1)
		{
		}

		[Constructable]
		public GhostBone(int amount) : base(0xf7e)
		{
			Name = "Ghost Bone";
			Hue = 2066;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public GhostBone(Serial serial) : base(serial)
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
