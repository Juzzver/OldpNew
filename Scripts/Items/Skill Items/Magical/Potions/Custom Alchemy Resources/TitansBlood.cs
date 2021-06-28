using System;
using Server.Items;

namespace Server.Items
{
	public class TitansBlood : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public TitansBlood() : this(1)
		{
		}

		[Constructable]
		public TitansBlood(int amount) : base(0xf7e)
		{
			Name = "Titans Blood";
			Hue = 1920;
			Stackable = true;
			Amount = amount;
			Weight = 1.0;
		}

		public TitansBlood(Serial serial) : base(serial)
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
