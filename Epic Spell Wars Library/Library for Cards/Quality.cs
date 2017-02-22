using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Spell_Wars_Library.Library_for_Cards
{
    class Quality : Spell
    {
        public Quality(int id)
            : base(id)
        {            
            base.PosInInvoke = Position.Mid;
        }
    }
}
