using System;
using Server.Items;

namespace Server.Items
{
	public class CovetousKeeperBone : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public CovetousKeeperBone() : this(1)
		{
		}

		[Constructable]
		public CovetousKeeperBone(int amount) : base(0xf7e)
		{
			Name = "Covetous Keeper Bone";
			Hue = 1287;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public CovetousKeeperBone(Serial serial) : base(serial)
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
