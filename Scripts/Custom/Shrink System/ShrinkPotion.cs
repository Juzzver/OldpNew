#region AuthorHeader
//
//	Shrink System version 2.1, by Xanthos
//
//
#endregion AuthorHeader
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;
using Server.Spells;

namespace Xanthos.ShrinkSystem
{
    [Flipable( 0x14E8, 0x14E7 )]
    public class ShrinkPotion : Item, IShrinkTool
    {
        private int m_Charges = ShrinkConfig.ShrinkCharges;

        [CommandProperty( AccessLevel.GameMaster )]
        public int ShrinkCharges
        {
            get { return m_Charges; }
            set
            {
                if ( 0 == m_Charges || 0 == (m_Charges = value) )
                    Delete();
                else
                    InvalidateProperties();
            }
        }

        public override bool ForceShowProperties { get { return ObjectPropertyList.Enabled; } }

        [Constructable]
        public ShrinkPotion()
            : this( 1 )
        {
        }

        [Constructable]
        public ShrinkPotion( int charges )
            : base( 0xF04 )
        {
            Name = "Shrink Potion";
            m_Charges = charges;
        }

        public ShrinkPotion( Serial serial )
            : base( serial )
        {
        }

        public override void AddNameProperties( ObjectPropertyList list )
        {
            base.AddNameProperties( list );

            if ( m_Charges >= 0 )
                list.Add( 1060658, "Charges\t{0}", m_Charges.ToString() );
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( !IsChildOf( from.Backpack ) )
            {
                from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
                return;
            }

            if ( SpellHelper.CheckCombat( from ) )
            {
                from.SendMessage( "You are cannot use shrink potion in battle." );
                return;
            }
            else if ( from.InRange( this.GetWorldLocation(), 2 ) == false )
                from.SendLocalizedMessage( 500486 ); //That is too far away.

              else if ( from.Skills[SkillName.AnimalTaming].Value >= ShrinkConfig.TamingRequired )
                  from.Target = new ShrinkTarget( from, this, false );
              else
                  from.SendMessage( "You must have at least " + ShrinkConfig.TamingRequired + " animal taming to use a hitching post." );
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 ); // version
            writer.Write( m_Charges );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
            m_Charges = reader.ReadInt();
        }
    }
}
