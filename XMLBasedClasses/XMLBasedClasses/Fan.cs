using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class Fan
    {
        public Fan(int size)
        {
            HasLED = false;
            SizeInMM = size;
        }

        public Fan(int size, LED led)
        {
            HasLED = true;
            SizeInMM = size;
            LED = led;
        }

        public bool HasLED
        {
            get;
            private set;
        }

        public int SizeInMM
        {
            get;
            private set;
        }

        public LED LED
        {
            get;
            private set;
        }
    }
}
