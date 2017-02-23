using Epic_Spell_Wars_Library.Library_for_Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Spell_Wars_Library
{
    public class CardDecks
    {
        public const ushort COUNT_SPELLS = 128;
        public const ushort COUNT_TREASURES = 25;
        public const ushort COUNT_DEADWIZARDSPELLS = 25;
        //public const ushort COUNT_CARDS = COUNT_SPELLS + COUNT_TREASURES + COUNT_DEADWIZARDSPELLS;

        public readonly static Spell[] _allSpells = InitSpells();
        public readonly static Treasure[] _allTreasures = InitTreasures();
        public readonly static DeadWizardSpell[] _allDeadWizardSpells = InitDeadWizardSpells();

        //internal static Spell[] AllSpells
        //{
        //    get { return CardDecks._allSpells; }            
        //}        

        //internal static Treasure[] AllTreasures
        //{
        //    get { return CardDecks._allTreasures; }            
        //}        

        //internal static DeadWizardSpell[] AllDeadWizardSpells
        //{
        //    get { return CardDecks._allDeadWizardSpells; }            
        //}

        private static Spell[] InitSpells()
        {
            Spell[] result = new Spell[COUNT_SPELLS];

            //создать объекты каждого спэлла 

            return result;
        }

        private static Treasure[] InitTreasures()
        {
            Treasure[] result = new Treasure[COUNT_TREASURES];

            //создать oбъекты каждого сокровища

            return result;
        }

        private static DeadWizardSpell[] InitDeadWizardSpells()
        {
            DeadWizardSpell[] result = new DeadWizardSpell[COUNT_DEADWIZARDSPELLS];

            //создать объекты каждого заклинания дохлого колдуна

            return result;
        }

        private Stack<ushort> _currentDeckSpells = new Stack<ushort>(COUNT_SPELLS);
        private Stack<ushort> _currentDeckTreasures = new Stack<ushort>(COUNT_TREASURES);
        private Stack<ushort> _currentDeckDeadWizardSpells = new Stack<ushort>(COUNT_DEADWIZARDSPELLS);

        private List<ushort> _deckDiscardSpells = InitList(COUNT_SPELLS); // можна попробовать изменить на SortedSet, чтобы элементы не повторялись
        private List<ushort> _deckDiscardTreasures = InitList(COUNT_TREASURES); // можна попробовать изменить на SortedSet, чтобы элементы не повторялись
        private List<ushort> _deckDiscardDeadWizardSpells = InitList(COUNT_DEADWIZARDSPELLS); // можна попробовать изменить на SortedSet, чтобы элементы не повторялись

        public ushort GetSpell()
        {
            if (_currentDeckSpells.Count == 0)
                ShuffleDeckSpells();
             
            return _currentDeckSpells.Pop();
        }

        //добавить методы GetDead...(), GetTrea...()
        //         методы ThrowInRetreatTr...(), ThrowI...()
        //         ShuffleDeckTrea...(), ShuffleDeckDea...()
        public void ThrowInRetreatSpells(ushort disc_sp)
        {
            _deckDiscardSpells.Add(disc_sp);
        }

        //просто инициализация индексов для отбоя, то есть исходно индексов всех карт
        private static List<ushort> InitList(ushort count)
        {
            List<ushort> list = new List<ushort>();
            for (ushort i = 0; i < count; i++)
            {
                list.Add(i);
            }
            return list;
        }
        
        //перетасовка
        public void ShuffleDeckSpells()
        {       
            Random rand = new Random();
            for (ushort i = 0; this._deckDiscardSpells.Count != 0;)   
            {
                i = (ushort)rand.Next(0, this._deckDiscardSpells.Count);
                _currentDeckSpells.Push(_deckDiscardSpells[i]);
                _deckDiscardSpells.RemoveAt(i);                
            }   
        }

        public CardDecks() 
        {
            ShuffleDeckSpells(); //не факт, что логично в конструкторе, но всё же в остальных случаях будет перетасовка из отбоя
            //ShuffleDeckTrea...(); 
            //ShuffleDeckDea...()
        }
    }
}
