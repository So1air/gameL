using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Spell_Wars_Library.Library_for_Cards.Cards_Source
{
    //от короля Оберона
    sealed class KingOberon : Source
    {
        public override void Play(sbyte ownerCard, Player[] players, CardDecks currDecks)
        {
            if(players[ownerCard].IsLive)
                players[ownerCard].HealthWizard += 2;
        }

        public KingOberon(int id)
            : base(id)
        {
            base.Glyph = MagicalGlyph.Primal;                      
        }
    }
}
