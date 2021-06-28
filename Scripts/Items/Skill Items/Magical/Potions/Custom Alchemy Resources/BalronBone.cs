using System;
using Server.Items;

namespace Server.Items
{
	public class BalronBone : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public BalronBone() : this(1)
		{
		}

		[Constructable]
		public BalronBone(int amount) : base(0xf7e)
		{
			Name = "Balron Bone";
			Hue = 1910;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public BalronBone(Serial serial) : base(serial)
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
