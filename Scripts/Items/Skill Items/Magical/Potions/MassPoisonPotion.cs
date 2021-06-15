using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class MassPoisonPotion : BasePotion
	{
		[Constructable]
		public MassPoisonPotion() : base( 0xF0A, PotionEffect.MassPoison )
		{
			Hue = 1167;
			Name = "Mass Poison Potion";
		}

		public MassPoisonPotion( Serial serial ) : base( serial )
		{
		}
		
		public override void Drink( Mobile from )
		{

			DoPoison(from);

			Consume();

			PlayDrinkEffect( from );
		}

		public void DoPoison(Mobile from)
		{
			var mobiles = from.GetMobilesInRange(7);
			List<Mobile> targets = new List<Mobile>();

			foreach (var mobile in mobiles)
			{
				if (SpellHelper.ValidIndirectTarget(from, mobile) && from.CanSee(mobile) && from.CanBeHarmful(mobile, false) && mobile != from)
					targets.Add(mobile);

				for (int i = 0; i < targets.Count; ++i)
				{
					Mobile m = targets[i];

					from.DoHarmful(mobile);

					m.FixedParticles(0x374A, 10, 15, 5028, EffectLayer.Waist);
					m.PlaySound(0x1FB);

					m.ApplyPoison(from, Poison.Greater);

				//	HarmfulSpell(m);
				//	m.harmfu
				}
			}
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
