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
        public sealed string _NickName; //?
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

        private List<ushort> _invoke = new List<ushort>(); //изменить на объект класса с инициативой соответственно равной заклинанию
        
        public List<ushort> Invoke
        {
            get { return _invoke; }
            set { _invoke = value; }
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


        public void Reanimate() 
        { }

        public void DrawSpells(CardDecks currDecks) 
        { }

        public void DrawDeadWizardSpell(CardDecks currDecks)
        { }

        public void DrawTreasure(CardDecks currDecks)
        { }

        public int ThrowDice()
        {
            Random r = new Random();
            return r.Next(1, 7);
        }
        void CreateInvoke(Spell spell_beg, Spell spell_mid, Spell spell_end);

        //?void? CastSpell(sbyte number_spell);
        //?void? CastInvoke();         

        public Player(string nick, string connection_info)
        {            
            _NickName = nick;
            _ConnectionInfo = connection_info;
        }
    }
}
