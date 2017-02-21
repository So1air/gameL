using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Spell_Wars_Library.Library_for_Cards
{
    public abstract class DeadWizardSpell : Card
    {
        public void OnRevivalWizard(/*тут передать Player[] и номер ожившего*/) { }

        public DeadWizardSpell(int id)
	     :base(id)
        {
            base.Glyph = MagicalGlyph.None;
        }
    }
}
