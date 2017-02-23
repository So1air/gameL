using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Spell_Wars_Library.Library_for_Cards
{
    public abstract class Spell : Card
    {
        public enum Position
        {
            Uni,
            Beg,
            Mid,        
            End
        }

        public readonly ushort? Initiative{ public get; protected set; }

        public readonly Position PosInInvoke
        {
            public get;
            protected set;
        }

        //нашёл другое решение для неё
        //public virtual void ActionBeforeCreateInvoke(sbyte ownerCard, Player[] players, CardDecks currDecks); //для карты Нетерпеливый

        public virtual void Play(/*тут должны быть переданы игроки и колода*/sbyte ownerCard, Player[] players, CardDecks currDecks);

        public Spell(int id)
            : base(id) { }
    }
}
