//using Server.Items;

//namespace Server.Items
//{
//	public class BeastHunter : Bow
//	{
//		public override int AosMinDamage { get { return 100; } }
//		public override int AosMaxDamage { get { return 110; } }
//		public override int AosSpeed { get { return 25; } }
//		public override float MlSpeed { get { return 4.25f; } }

//		[Constructable]
//		public BeastHunter() 
//		{
//			Name = "Beast Hunter";
//			Hue = 1133;
//			Slayer = SlayerName.TrollSlaughter;
//			Slayer2 = SlayerName.OgreTrashing;
//			// Дает шанс 40 процентов нанести дополнительный урон 100  по ограм и тролям.
//		}

//		public BeastHunter(Serial serial) : base(serial)
//		{
//		}

//		public override void Serialize(GenericWriter writer)
//		{
//			base.Serialize(writer);

//			writer.Write((int)0); // version
//		}

//		public override void Deserialize(GenericReader reader)
//		{
//			base.Deserialize(reader);

//			int version = reader.ReadInt();
//		}
//	}
//}
