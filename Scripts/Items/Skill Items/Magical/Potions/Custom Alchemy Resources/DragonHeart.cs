using System;
using Server.Items;

namespace Server.Items
{
	public class DragonHeart : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public DragonHeart() : this(1)
		{
		}

		[Constructable]
		public DragonHeart(int amount) : base(0xF91)
		{
			Name = "Dragon Heart";
			Hue = 1287;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public DragonHeart(Serial serial) : base(serial)
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