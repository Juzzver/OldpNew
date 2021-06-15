using System;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class BaseRestorationPotion : BaseHealPotion
	{
		public override int MinHeal { get; }
		public override int MaxHeal { get; }
		public virtual int OverHitsBonus { get; }
		public override double Delay{ get{ return 15; } }
		public virtual double EffectDuration { get { return 30; } }


		public BaseRestorationPotion() : base( PotionEffect.Restoration )
		{
			ItemID = 0x0F00;
		}

		public BaseRestorationPotion( Serial serial ) : base( serial )
		{
		}

		public override void Drink(Mobile from)
		{
			if (from.Hits < from.HitsMax)
			{
				if (from.Poisoned || MortalStrike.IsWounded(from))
				{
					from.LocalOverheadMessage(MessageType.Regular, 0x22, 1005000); // You can not heal yourself in your current state.
				}
				else
				{
					if (from.BeginAction(typeof(BaseRestorationPotion)))
					{
						DoHeal(from);

						BasePotion.PlayDrinkEffect(from);

						if (!Engines.ConPVP.DuelContext.IsFreeConsume(from))
							this.Consume();

						if (this is HeroRestorationPotion && from is PlayerMobile)
						{
							((PlayerMobile)from).RestorationBonus = OverHitsBonus;

							Timer.DelayCall(TimeSpan.FromSeconds(EffectDuration), () =>
							{
								((PlayerMobile)from).RestorationBonus = 0;
								from.SendMessage("Hero Restoration effect is end.");
								from.Delta(MobileDelta.Hits);
							});
						}

						Timer.DelayCall(TimeSpan.FromSeconds(Delay), new TimerStateCallback(ReleaseRestorationLock), from);
					}
					else
					{
						//from.LocalOverheadMessage( MessageType.Regular, 0x22, 500235 ); // You must wait 10 seconds before using another healing potion.
						from.LocalOverheadMessage(MessageType.Regular, 0x22, true, $"You must wait {Delay} seconds before using another restoration potion.");
					}
				}
			}
			else
			{
				from.SendLocalizedMessage(1049547); // You decide against drinking this potion, as you are already at full health.
			}
		}

		private static void ReleaseRestorationLock(object state)
		{
			((Mobile)state).EndAction(typeof(BaseRestorationPotion));
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
