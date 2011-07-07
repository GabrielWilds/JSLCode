using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using Numberguesser2011;

namespace Arena
{
    class DamageInfo
    {
        public Character Attacker
        {
            get;
            set;
        }
        public int Damage
        {
            get;
            set;
        }

        public NegStatus StatusEffect
        {
            get;
            set;
        }
    }
}
