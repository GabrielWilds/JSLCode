using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class Motherboard
    {
        public Motherboard(string brand, string size, string socket, string ramtype, int ramslots)
        {
            Brand = brand;
            Size = size;
            CPUSocket = socket;
            RAMType = ramtype;
            RAMSlots = ramslots;
        }

        public string Brand
        {
            get;
            private set;
        }

        public string Size
        {
            get;
            private set;
        }

        public string CPUSocket
        {
            get;
            private set;
        }

        public string RAMType
        {
            get;
            private set;
        }

        public int RAMSlots
        {
            get;
            private set;
        }
    }
}
