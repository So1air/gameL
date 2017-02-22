using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Spell_Wars_Library.Library_for_Cards
{
    public abstract class Card : IQuestion
    {
        public enum MagicalGlyph
        {
            None = 0,        //без знака
            Arcane = 1,      //Порча
            Primal = 2,      //Трава
            Elemental = 3,   //Угар
            Dark = 4,        //Мрак
            Illusion = 5     //Кумар
        }

        public sealed int Id 
        { 
            public get; 
            protected set;
        }

        //sealed string Name
        //{
        //    public get;
        //    protected set;
        //}

        //sealed string Declaration
        //{
        //    public get;
        //    protected set;
        //}

        public sealed MagicalGlyph Glyph
        {
            get;
            protected set;
        }

        private sealed Question QuestionOfChoice //a надо ли это свойство, ведь всё-равно оно изменяется и выдается 
                                                 //только из метода GetQuestion(...), хотя нам же надо где-то 
                                                 //хранить сформировавшиеся ответы
        {
            get;
            protected set;
        }

        public virtual Question GetQuestion(sbyte ownerCard, Player[] players, CardDecks currDecks);

        public virtual bool Choice(int number_choice) { return true; }

        public virtual void Draw(/*тут должны быть переданы игроки и колода*/) { }

        public virtual void OpenInvoke(/*тут должны быть переданы игроки и колода*/) { }        

        public virtual void Discard(/*тут должны быть переданы игроки и колода*/) { }

        public Card(int id)
        {
            this.Id = id;
        }
     }
}
