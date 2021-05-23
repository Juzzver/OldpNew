using Server.Items;

namespace Server.Items
{
	public class FrozenBow : Bow
	{
		public override int AosMinDamage { get { return 70; } }
		public override int AosMaxDamage { get { return 90; } }
		public override int AosSpeed { get { return 25; } }
		public override float MlSpeed { get { return 4.25f; } }

		[Constructable]
		public FrozenBow() 
		{
			Name = "Frozen Bow";
			Hue = 1152;
			// Paralyze
		}

		public FrozenBow(Serial serial) : base(serial)
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
