using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Spell_Wars_Library.Library_for_Cards
{
    class Delivery : Spell
    {
        public Delivery(int id)
            : base(id)
        {
            base.PosInInvoke = Position.End;
        }
    }
}
