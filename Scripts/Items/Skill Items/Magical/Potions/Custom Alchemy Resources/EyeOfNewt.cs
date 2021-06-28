using System;

namespace Server.Items
{
	public class EyeOfNewt : Item
	{

		[Constructable]
		public EyeOfNewt() : base(0xF87)
		{
			Movable = true;
			Stackable = true;
		}

		public EyeOfNewt(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
