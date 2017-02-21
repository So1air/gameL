using System;

namespace Epic_Spell_Wars_Library
{
    interface IQuestion
    {        
        Question GetQuestion(sbyte ownerCard, Epic_Spell_Wars_Library.Player[] players, Epic_Spell_Wars_Library.CardDecks currDecks);
        bool Choice(int number_choice);
    }
}
