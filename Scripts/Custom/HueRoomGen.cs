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
	public class GenerateHueRoom
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GenHueRoom", AccessLevel.Administrator, new CommandEventHandler( GenerateHueRoom_OnCommand ) );
		}

		[Usage( "GenHueRoom" )]
		[Description( "Generates a 50X60 Grid including spacing with hues ranged from 0-3000." )]
		public static void GenerateHueRoom_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Please wait for the dye tubs to be generated." );

            int shift = 2;

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
					for ( int y = 0; y <= 29; ++y )
					{
						Robe r = new Robe();
						r.Hue = ((100 * y) + x);
						r.Name = Convert.ToString(r.Hue);
                      // r.AddLabel(new PropertyLabel("ColorType"));
						r.ItemID = 15119;
						r.Movable = false;
						if (r != null) r.MoveToWorld( new Point3D( (MX + (shift * x)), (MY + (shift * y)), MZ ), map );
					}
				}
			}

			e.Mobile.SendMessage( "The Ultimate Hue Room Is Complete." );
		}

	}
}
