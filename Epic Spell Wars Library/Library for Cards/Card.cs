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

        //все существенные знаки -- без элемента None
        public static List<MagicalGlyph> AllGlyphs()
        {
            List<MagicalGlyph> res = new List<MagicalGlyph>();
            for(int i = 1; i < 6; i++)
                res.Add((MagicalGlyph)i);

            return res;
        }

        /*идентификатор карты(предполагаемое использование -- для определения класса карты в целях отображения пользователю на клиенте 
        соответствующих изображений; сами же классы конкретных карт будут недоступны вне библиотеки(сборки)) */
        public readonly int Id 
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

        public MagicalGlyph Glyph
        {
            get;
            protected set;
        }

        private Question QuestionOfChoice //a надо ли это свойство, ведь всё-равно оно изменяется и выдается 
                                                 //только из метода GetQuestion(...), хотя нам же надо где-то 
                                                 //хранить сформировавшиеся ответы
        {
            get;
            protected set;
        }

        public virtual Question GetQuestion(sbyte ownerCard, Player[] players, CardDecks currDecks) { return null; }

        public virtual bool Choice(int number_choice) 
        { 
            return true; //возврат оценки корректности ответа number_choice 
        }

        public virtual void Draw(sbyte ownerCard, Player[] players, CardDecks currDecks) { }

        public virtual void OpenInvoke(sbyte ownerCard, Player[] players, CardDecks currDecks) { }

        public virtual void Discard(sbyte ownerCard, Player[] players, CardDecks currDecks) { }

        public Card(int id)
        {
            this.Id = id;
        }
     }
}
