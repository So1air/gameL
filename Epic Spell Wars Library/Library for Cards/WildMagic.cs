using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Spell_Wars_Library.Library_for_Cards
{
    public class WildMagic : Spell
    {
        public WildMagic(int id)
            : base(id)
        {
            base.PosInInvoke = Position.Uni;
            base.Glyph = MagicalGlyph.None;            
        }
    }
}
