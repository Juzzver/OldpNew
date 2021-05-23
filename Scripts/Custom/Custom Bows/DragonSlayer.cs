using Server.Items;

namespace Server.Items
{
	public class DragonSlayer : Bow
	{
		public override int AosMinDamage { get { return 100; } }
		public override int AosMaxDamage { get { return 100; } }
		public override int AosSpeed { get { return 25; } }
		public override float MlSpeed { get { return 4.25f; } }

		[Constructable]
		public DragonSlayer() 
		{
			Name = "Dragon Slayer";
			Hue = 1133;
			Slayer = SlayerName.DragonSlaying;
			// Урон 100  Дает дополнительный урон по драконам  х2
		}

		public DragonSlayer(Serial serial) : base(serial)
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
