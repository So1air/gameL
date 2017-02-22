using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Spell_Wars_Library.Library_for_Cards.Cards_Quality
{
    //каменючный
    sealed class Boulder_iffic : Quality
    {
        public sealed override void Play(sbyte ownerCard, Player[] players, CardDecks currDecks)
        {
            for (int i = 1, damage = 0, target; i < players.Length; i++)
            {
                target = (ownerCard + i >= players.Length) ? (players.Length - i - ownerCard) : (ownerCard + i);
                if (players[target].IsLive)
                    players[target].HealthWizard -= ++damage;
            }                
        }

        public Boulder_iffic(int id)
            : base(id)
        {
            base.Glyph = MagicalGlyph.Primal;
        }
    }
}
