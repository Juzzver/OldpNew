using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class RevealPotion : BasePotion
	{
		[Constructable]
		public RevealPotion() : base( 0xF0A, PotionEffect.Reveal )
		{
			Hue = 1154;
			Name = "Reveal Potion";
		}

		public RevealPotion( Serial serial ) : base( serial )
		{
		}
		
		public override void Drink( Mobile from )
		{

			var mobiles = from.GetMobilesInRange(7);
			List<Mobile> targets = new List<Mobile>();

			foreach (var mobile in mobiles)
			{
				if (mobile != from && mobile.Alive && mobile.AccessLevel == AccessLevel.Player && mobile.Hidden)
					targets.Add(mobile);
			}

			mobiles.Free();

			for (int i = 0; i < targets.Count; i++)
			{
				Mobile m = targets[i];

				m.RevealingAction();
				m.SendMessage("You have been revealed!");
			}

			Consume();

			PlayDrinkEffect( from );
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
