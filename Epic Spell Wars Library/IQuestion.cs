using System;

namespace Epic_Spell_Wars_Library
{
    interface IQuestion
    {        
        Question GetQuestion(sbyte ownerCard, Player[] players, CardDecks currDecks);
        bool Choice(int number_choice);
    }
}
