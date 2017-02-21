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
        public const ushort COUNT_CARDS = COUNT_SPELLS + COUNT_TREASURES + COUNT_DEADWIZARDSPELLS;

        private sealed static Spell[] _allSpells = InitSpells();
        private sealed static Treasure[] _allTreasures = InitTreasures();
        private sealed static DeadWizardSpell[] _allDeadWizardSpells = InitDeadWizardSpells();

        internal static Spell[] AllSpells
        {
            get { return CardDecks._allSpells; }            
        }        

        internal static Treasure[] AllTreasures
        {
            get { return CardDecks._allTreasures; }            
        }        

        internal static DeadWizardSpell[] AllDeadWizardSpells
        {
            get { return CardDecks._allDeadWizardSpells; }            
        }

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

        private List<ushort> _currentDeckSpells = new List<ushort>(COUNT_SPELLS);
        private List<ushort> _currentDeckTreasures = new List<ushort>(COUNT_TREASURES);
        private List<ushort> _currentDeckDeadWizardSpells = new List<ushort>(COUNT_DEADWIZARDSPELLS);

        private List<ushort> _deckDiscardSpells = new List<ushort>();
        private List<ushort> _deckDiscardTreasures = new List<ushort>();
        private List<ushort> _deckDiscardDeadWizardSpells = new List<ushort>();
    }
}
