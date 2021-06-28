using System;
using Server.Items;

namespace Server.Items
{
	public class DestardKeeperBone : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public DestardKeeperBone() : this(1)
		{
		}

		[Constructable]
		public DestardKeeperBone(int amount) : base(0xf7e)
		{
			Name = "Destard Keeper Bone";
			Hue = 1175;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public DestardKeeperBone(Serial serial) : base(serial)
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
