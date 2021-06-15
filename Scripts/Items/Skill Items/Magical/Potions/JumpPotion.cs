using System;
using System.Collections;
using Server;
using Server.Spells.Fifth;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class JumpPotion : BasePotion
	{
		[Constructable]
		public JumpPotion() : base( 0xF0A, PotionEffect.Paralyze )
		{
			Hue = 1153;
			Name = "Jump Potion";
		}

		public JumpPotion( Serial serial ) : base( serial )
		{
		}
		
		public override void Drink( Mobile from )
		{
			from.Spell = new TeleportSpell(from, this);
			(from.Spell as TeleportSpell).State = Spells.SpellState.Sequencing;
			from.Target = new TeleportSpell.InternalTarget(from.Spell as TeleportSpell);

			if (from.Combatant != null)
				(from.Spell as TeleportSpell).Target(from.Combatant);

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
