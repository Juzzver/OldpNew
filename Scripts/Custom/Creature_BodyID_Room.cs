using System;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Commands.Generic;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server
{
	public class GenerateBodyIDRoom
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GenBodyIDRoom", AccessLevel.Administrator, new CommandEventHandler( GenerateBodyIDRoom_OnCommand ) );
		}

		public class BodyIDCreature : BaseCreature
		{
			public BodyIDCreature() : base(AIType.AI_Animal, FightMode.None, 0, 0, 1,1)
			{				
				CantWalk = true;
				Blessed = true;
				Direction = Direction.Down;
			}

			public override void OnDoubleClick(Mobile from)
			{
				if (Direction < Direction.ValueMask)
					Direction++;
				else
					Direction = Direction.North;

			}

			public override void AddNameProperties(ObjectPropertyList list)
			{
				base.AddNameProperties(list);

				list.Add(BodyValue.ToString());
			}

			public BodyIDCreature(Serial serial) : base(serial)
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

		[Usage("GenBodyIDRoom")]
		[Description( "Generates a 50X60 Grid including spacing with creature body ID ranged from 0-3000." )]
		public static void GenerateBodyIDRoom_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Please wait for the dye tubs to be generated." );

            int shift = 3;

            if (e.Arguments != null && e.Arguments.Length > 0)
            {
                Int32.TryParse(e.Arguments[0], out shift);
            }

            Map map = e.Mobile.Map;
			int MX = e.Mobile.X;
			int MY = e.Mobile.Y;
			int MZ = e.Mobile.Z;

			if ( map != null )
			{
				for ( int x = 0; x <= 99; ++x )
				{
					for ( int y = 0; y <= 20; ++y )
					{
						BodyIDCreature mob = new BodyIDCreature();
						mob.BodyValue = ((100 * y) + x);

						//if (mob.Body.IsEmpty)
						//{
						//	mob.Delete();
						//	continue;
						//}

						//	r.Name = Convert.ToString(r.Hue);
						// r.AddLabel(new PropertyLabel("ColorType"));
						//r.ItemID = 15119;
						//r.Movable = false;
						if (mob != null)
							mob.MoveToWorld( new Point3D( (MX + (shift * x)), (MY + (shift * y)), MZ ), map );
					}
				}
			}

			e.Mobile.SendMessage("Generate ids of mobs are complete.");
		}

	}
}
