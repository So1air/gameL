using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epic_Spell_Wars_Library.Library_for_Cards;

namespace Epic_Spell_Wars_Library
{
    public class Player // : IEnemy_sView
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
        //поле для определения индекса в массиве игроков
        private readonly sbyte _placeOnBattleField; 

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

        private byte maxCountSpells = START_COUNT_SPELLS;
        private List<ushort> _spellsOnHand = new List<ushort>();        
        private List<ushort> _treasures = new List<ushort>();
        private List<ushort> _deadWizardSpells = new List<ushort>();

        private List<ushort> _invoke = new List<ushort>();
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

        public List<ushort> Invoke                           //думаю, ошибочно предоставлять такой доступ
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
        //посмотреть спэллы в руке(например, для менеджера игры нужно)
        public List<int> PeekSpellsOnHand()
        {
            List<int> IDs_spells = new List<int>();
            foreach(ushort sp in _spellsOnHand)
                IDs_spells.Add(CardDecks._allSpells[sp].Id);
            return IDs_spells;
        }

        //посмотреть спэллы дохлых
        public List<int> PeekDeadWizardSpells()
        {
            List<int> IDs_deadWizardSpells = new List<int>();
            foreach (ushort dwsp in _deadWizardSpells)
                IDs_deadWizardSpells.Add(CardDecks._allDeadWizardSpells[dwsp].Id);
            return IDs_deadWizardSpells;
        }

        //посмотреть сокровища
        public List<int> PeekTreasures()
        {
            List<int> IDs_treasures = new List<int>();
            foreach (ushort tr in _treasures)
                IDs_treasures.Add(CardDecks._allTreasures[tr].Id);
            return IDs_treasures;
        }

        //посмотреть заклинание
        public int[] PeekInvoke()
        {
            int[] res = new int[_invoke.Count];
            int i = -1;
            foreach(ushort sp in _invoke)
                res[++i] = CardDecks._allSpells[sp].Id;

            return res;
        }

        //подсчёт уникального количества знаков в заклинании(а также в сокровищах)
        public sbyte CountUniqueGlyphsInInvoke()
        {
            sbyte res = 0;
            sbyte counter_glyph;
            List<ushort> spellsInInvoke_and_treasure = new List<ushort>(_invoke);
            spellsInInvoke_and_treasure.AddRange(_treasures);                           //может быть ошибка
            List<Card.MagicalGlyph> glyphs = Card.AllGlyphs();
            foreach(Card.MagicalGlyph gl in glyphs){
                counter_glyph = 0;
                foreach (ushort j in spellsInInvoke_and_treasure)
                    if (gl == CardDecks._allSpells[j].Glyph)
                        counter_glyph++;
                if (counter_glyph == 1)
                    res++;
            }            

            return res;
        }

        //подсчёт количества встречаний определённого знака в заклинании
        public sbyte CountTheGlyphInInvoke(Card.MagicalGlyph m_gl)
        {
            sbyte counter = 0;
            foreach (ushort sp in _invoke)
                if (CardDecks._allSpells[sp].Glyph == m_gl)
                    counter++;
            foreach (ushort tr in _treasures)
                if (CardDecks._allTreasures[tr].Glyph == m_gl)
                    counter++;
            
            return counter;
        }

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
        {
            _deadWizardSpells.Add(currDecks.GetDeadWizardSpell());
        }

        //берём сокровище
        public void DrawTreasure(CardDecks currDecks)
        {
            _treasures.Add(currDecks.GetTreasure());
            //разыграть метод Draw() для сокровища
        }

        //бросок кубика
        public int ThrowDice()
        {
            Random r = new Random();
            return r.Next(1, COUNT_FACES_OF_DICE + 1);
        }

        //составление заклинания
        public bool LayDownInInvoke(ushort ind_sp)
        {
            if (_invoke.Count == 3)
                return false;
            
            foreach (ushort i in _invoke)
                if(CardDecks._allSpells[ind_sp].PosInInvoke != Spell.Position.Uni)
                    if (CardDecks._allSpells[ind_sp].PosInInvoke == CardDecks._allSpells[i].PosInInvoke)
                        return false;                  
            
            if (_invoke.Count == 0)
                _invoke.Add(ind_sp); 
            else 
                if (_invoke.Count == 1)
                    switch (CardDecks._allSpells[ind_sp].PosInInvoke)
                    {
                        case Spell.Position.Beg:
                            _invoke.Insert(0, ind_sp);
                            break;

                        case Spell.Position.Mid: 
                        case Spell.Position.Uni:
                            if (CardDecks._allSpells[_invoke[0]].PosInInvoke == Spell.Position.End)
                                _invoke.Insert(0, ind_sp);
                            else _invoke.Add(ind_sp);
                            break;

                        case Spell.Position.End:
                            _invoke.Add(ind_sp);
                            break;                            
                    }
                else
                    switch (CardDecks._allSpells[ind_sp].PosInInvoke)
                    { 
                        case Spell.Position.Beg:
                            if ((CardDecks._allSpells[_invoke[0]].PosInInvoke == Spell.Position.Uni)
                                    && (CardDecks._allSpells[_invoke[1]].PosInInvoke == Spell.Position.Mid))
                            {
                                _invoke.Add(_invoke[0]);
                                _invoke[0] = ind_sp;
                            }
                            else _invoke.Insert(0, ind_sp);
                            break;
 
                        case Spell.Position.Mid:
                            _invoke.Insert(1, ind_sp);
                            break;

                        case Spell.Position.End:
                            _invoke.Add(ind_sp);
                            break;

                        case Spell.Position.Uni:
                            switch (CardDecks._allSpells[_invoke[0]].PosInInvoke)
                            {
                                case Spell.Position.Beg:
                                    if (CardDecks._allSpells[_invoke[1]].PosInInvoke == Spell.Position.End)
                                        _invoke.Insert(1, ind_sp);
                                    else _invoke.Add(ind_sp);
                                    break;

                                case Spell.Position.Mid:
                                    _invoke.Insert(0, ind_sp);
                                    break;

                                case Spell.Position.Uni:
                                    if (CardDecks._allSpells[_invoke[1]].PosInInvoke == Spell.Position.End)
                                        _invoke.Insert(1, ind_sp);
                                    else _invoke.Add(ind_sp);
                                    break;
                            }
                            break;
                    }

            _spellsOnHand.Remove(ind_sp);
            return true;
        }

        public bool DelSpellFromInvoke(int number) //дописать
        {
            return true;
        }

        //продумать методы перед кастом каждой карты спэлла
        /*precastspell*/ 
        /*castspell*/
        //после каста последней карты _invoke сбросить карты _invoke в отбой, а значит в конце каста, именно в конце, проверять это 

        //?void? CastSpell(sbyte number_spell, Player[] players, CardDecks currDecks); //метод-кандидат каста спэлла
        
        #endregion

        //переделать
        public Player(string nick, string connection_info, sbyte place)
        {            
            _NickName = nick;
            _ConnectionInfo = connection_info;
            IsLive = true;
            _placeOnBattleField = place;
        }
    }
}
