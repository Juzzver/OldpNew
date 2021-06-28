using System;
using System.Collections;
using Server;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class MagicReflectionPotion : BasePotion
	{
		[Constructable]
		public MagicReflectionPotion() : base( 0xF0A, PotionEffect.MagicReflect )
		{
			Hue = 1150;
			Name = "Magic Reflection Potion";
		}

		public MagicReflectionPotion( Serial serial ) : base( serial )
		{
		}
		
		public override void Drink( Mobile from )
		{
			MagicReflectSpell.EndReflect(from);

			from.Spell = new MagicReflectSpell(from, this);
			(from.Spell as MagicReflectSpell).OnCast();

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
