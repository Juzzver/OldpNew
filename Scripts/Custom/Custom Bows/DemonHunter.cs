using Server.Items;

namespace Server.Items
{
	public class DemonHunter : Bow
	{
		public override int AosMinDamage { get { return 100; } }
		public override int AosMaxDamage { get { return 105; } }
		public override int AosSpeed { get { return 25; } }
		public override float MlSpeed { get { return 4.25f; } }

		[Constructable]
		public DemonHunter() 
		{
			Name = "Demon Hunter";
			Hue = 1140;
			Slayer = SlayerName.Exorcism;
			//Урон 100-105 Увеличенный урон по Демонам в два раза.
		}

		public DemonHunter(Serial serial) : base(serial)
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
