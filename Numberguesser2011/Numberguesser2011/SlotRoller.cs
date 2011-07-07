using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino
{
    class SlotRoller
    {
        public int GetFace(Array rollerArray)
        {
            int rollerResult = Randomizer.RandomNumber(rollerArray.Length);
            return rollerResult;
        }
    }
}
