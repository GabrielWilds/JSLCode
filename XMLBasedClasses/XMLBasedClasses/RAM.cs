using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class RAM
    {
        public RAM(int stickcount, string slot, int capacityinGB)
        {
            NumSticks = stickcount;
            SlotType = slot;
            CapacityInGB = capacityinGB;
        }

        public int NumSticks
        {
            get;
            set;
        }

        public string SlotType
        {
            get;
            private set;
        }

        public int CapacityInGB
        {
            get;
            set;
        }
    }
}
