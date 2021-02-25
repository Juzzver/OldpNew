using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Items
{
	public class BagOfArmor : Backpack
	{
		[Constructable]
		public BagOfArmor(CraftResource resource) : base()
		{
			Hue = CraftResources.GetHue(resource);

			this.Name = string.Format("a bag of {0} armor", resource.ToString());

			this.AddItem(new PlateHelm { Resource = resource, X = 44, Y = 45 });
			this.AddItem(new PlateGorget { Resource = resource, X = 85, Y = 68 });
			this.AddItem(new PlateArms { Resource = resource, X = 44, Y = 94 });
			this.AddItem(new PlateGloves { Resource = resource, X = 44, Y = 125 });
			this.AddItem(new PlateChest { Resource = resource, X = 94, Y = 89 });
			this.AddItem(new PlateLegs { Resource = resource, X = 142, Y = 115 });
			this.AddItem(new HeaterShield { Resource = resource, X = 136, Y = 65 });
		}

		[Constructable]
		public BagOfArmor(int resourceIndex) : this((CraftResource)resourceIndex)
		{

		}

		public BagOfArmor(Serial serial) : base(serial) { }

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
