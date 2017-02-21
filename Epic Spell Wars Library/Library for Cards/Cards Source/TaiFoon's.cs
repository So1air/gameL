using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Spell_Wars_Library.Library_for_Cards.Cards_Source
{
    //от Тай Тьфуна
    sealed class TaiFoon_s : Source
    {
        public override void Play(sbyte ownerCard, Player[] players, CardDecks currDecks)
        {
            for (int i = 0; i < players.Length; i++)
                if ((i != ownerCard) && (players[i].IsLive) && (players[i].IsCast))
                    players[i].HealthWizard -= 3;
        }

        public TaiFoon_s(int id) 
            : base(id)
        {
            base.Glyph = MagicalGlyph.Elemental;            
        }
    }
}
