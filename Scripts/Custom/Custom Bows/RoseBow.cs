using Server.Items;

namespace Server.Items
{
	public class RoseBow : Bow
	{
		public override int AosStrengthReq { get { return 30; } }
		public override int AosMinDamage { get { return 80; } }
		public override int AosMaxDamage { get { return 100; } }
		public override int AosSpeed { get { return 25; } }
		public override float MlSpeed { get { return 4.25f; } }

		[Constructable]
		public RoseBow() 
		{
			Name = "Rose Bow";
			Hue = 28;
			//Random Imbue
		}

		public RoseBow(Serial serial) : base(serial)
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
