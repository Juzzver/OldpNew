using System;
using Server;

namespace Server.Items
{
	public class LesserManaPotion : BaseManaPotion
	{
		public override int MinMana { get { return 15; } }
		public override int MaxMana { get { return 17; } }
		public override double Delay { get { return 8.0; } }

		[Constructable]
		public LesserManaPotion() : this(1)
		{
		}

		[Constructable]
		public LesserManaPotion(int amount) : base(PotionEffect.Mana, amount)
		{
			Name = "Lesser Mana Refresh";
		}

		public LesserManaPotion(Serial serial) : base(serial)
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
