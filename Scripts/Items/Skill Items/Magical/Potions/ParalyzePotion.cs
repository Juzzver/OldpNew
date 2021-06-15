using System;
using System.Collections;
using Server;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class ParalyzePotion : BasePotion
	{
		[Constructable]
		public ParalyzePotion() : base( 0xF0A, PotionEffect.Paralyze )
		{
			Hue = 1166;
			Name = "Paralyze Potion";
		}

		public ParalyzePotion( Serial serial ) : base( serial )
		{
		}
		
		public override void Drink( Mobile from )
		{
			from.Spell = new ParalyzeSpell(from, this);
			(from.Spell as ParalyzeSpell).State = Spells.SpellState.Sequencing;
			from.Target = new ParalyzeSpell.InternalTarget(from.Spell as ParalyzeSpell);

			Consume();

			PlayDrinkEffect( from );
		}

		private class ThrowTarget : Target
		{
			private ParalyzePotion m_Potion;

			public ParalyzePotion Potion
			{
				get { return m_Potion; }
			}

			public ThrowTarget(ParalyzePotion potion) : base(12, false, TargetFlags.Harmful)
			{
				m_Potion = potion;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Potion.Deleted || m_Potion.Map == Map.Internal)
					return;

				IPoint3D p = targeted as IPoint3D;

				if (p == null || from.Map == null)
					return;

				// Add delay
				BaseConflagrationPotion.AddDelay(from);

				//SpellHelper.GetSurfaceTop(ref p);

				from.RevealingAction();

				IEntity to;

				if (p is Mobile)
					to = (Mobile)p;
				else
					to = new Entity(Serial.Zero, new Point3D(p), from.Map);

				Effects.SendMovingEffect(from, to, 0xF0D, 7, 0, false, false, m_Potion.Hue, 0);
			//	Timer.DelayCall(TimeSpan.FromSeconds(1.5), new TimerStateCallback(m_Potion.Explode_Callback), new object[] { from, new Point3D(p), from.Map });
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
