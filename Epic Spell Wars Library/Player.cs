using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epic_Spell_Wars_Library.Library_for_Cards;

namespace Epic_Spell_Wars_Library
{
    public class Player
    {
        #region Константные параметры
        /// <summary>
        /// Количество заклинаний, в руке игрока в начале раунда.
        /// </summary>
        public const byte START_COUNT_SPELLS = 8;
        /// <summary>
        /// Уровень здоровья игрового персонажа в начале раунда.
        /// </summary>
        public const byte START_HEALTH_WIZARD = 20;
        /// <summary>
        /// Максимально допустимый уровень здоровья игрового персонажа.
        /// </summary>
        public const byte MAX_HEALTH_WIZARD = 25;
        /// <summary>
        /// Количество граней игральной кости.
        /// </summary>
        private const sbyte COUNT_FACES_OF_DICE = 6;
        #endregion

        #region Вынести в менеджера
        /// <summary>
        /// Ник игрока в даной игровой сессии.
        /// </summary>
        public readonly string _NickName; //?
        /// <summary>
        /// Информация необходимая для коннекта с клиентским приложением игрока.
        /// </summary>
        public string _ConnectionInfo; //?
        #endregion

        #region Поля и свойства
        private int healthWizard = START_HEALTH_WIZARD;        
        /// <summary>
        /// Получает и задает текущее здоровье игрового персонажа.
        /// </summary>
        public int HealthWizard
        {
            get { return healthWizard; }
            set 
            {
                if (value < 1)
                {
                    healthWizard = 0;
                    IsLive = false;
                }
                else if (value > MAX_HEALTH_WIZARD)
                    healthWizard = MAX_HEALTH_WIZARD;
                else 
                    healthWizard = value; 
            }
        }
        /// <summary>
        /// Возвращает значение, указывающее жив ли игровой персонаж в даный момент.
        /// </summary>
        public bool IsLive
        {
            public get;
            private set;
        }

        private List<ushort> _spellsOnHand = new List<ushort>();
        private byte maxCountSpells = START_COUNT_SPELLS;
        public readonly List<ushort> _treasures = new List<ushort>();
        public readonly List<ushort> _deadWizardSpell = new List<ushort>();

        private List<ushort> _invoke = new List<ushort>(); //изменить на объект класса с инициативой соответственно равной заклинанию
        public ushort? InititiativeInvoke
        {
            get
            {
                ushort? max = 0;
                foreach (ushort spell in _invoke)
                    if (CardDecks._allSpells[spell].Initiative != null)
                        if (CardDecks._allSpells[spell].Initiative > max)
                            max = CardDecks._allSpells[spell].Initiative;
                        else ;
                    else return null;
                return max;
            }
        }        

        public List<ushort> Invoke
        {
            get { return _invoke; }
            
        }
        /// <summary>
        /// Возвращает значение, указывающее ходил ли игрок в даном раунде.
        /// </summary>
        public bool IsCast
        {
            get
            {
                return _invoke.Count == 0;
            }
        }
        #endregion 

        #region Методы
        //оживление, тут можна разыграть дохлых
        public void Reanimate(/**/) //разбить на разные процедуры для каста каждого дохлого
        { }

        //добираем руку
        public void DrawSpells(CardDecks currDecks) 
        {
            while (_spellsOnHand.Count < maxCountSpells)
            {
                _spellsOnHand.Add(currDecks.GetSpell());
                //возможно разыграть метод Draw() спэлла
            }
        }

        //берём дохлого
        public void DrawDeadWizardSpell(CardDecks currDecks)
        { }

        //берём сокровище
        public void DrawTreasure(CardDecks currDecks)
        { }

        public int ThrowDice()
        {
            Random r = new Random();
            return r.Next(1, 7);
        }

        public bool LayDownInInvoke(ushort ind_sp)
        {
            if (_invoke.Count == 3)
                return false;
            
            foreach (ushort i in _invoke)
                if(CardDecks._allSpells[ind_sp].PosInInvoke != Spell.Position.Uni)
                    if (CardDecks._allSpells[ind_sp].PosInInvoke == CardDecks._allSpells[i].PosInInvoke)
                        return false;                  
            
            _invoke.Add(ind_sp); //изменить так, чтобы добавляло в нужную позицию
                   
            _spellsOnHand.Remove(ind_sp);
            return true;
        }        
        
        //продумать методы перед кастом каждой карты спэлла
        /*precastspell*/ 
        /*castspell*/
        //после каста последней карты _invoke сбросить карты _invoke в отбой, а значит в конце каста, именно в конце, проверять это 

        //?void? CastSpell(sbyte number_spell, Player[] players, CardDecks currDecks); //метод-кандидат каста спэлла                
        #endregion

        //переделать
        public Player(string nick, string connection_info)
        {            
            _NickName = nick;
            _ConnectionInfo = connection_info;
        }
    }
}
