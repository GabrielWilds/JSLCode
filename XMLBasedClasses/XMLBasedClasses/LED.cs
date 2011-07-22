using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class LED
    {
        public LED(string color, string brightnessDesc)
        {
            Color = color;
            BrightnessDescription = brightnessDesc;
        }

        public string Color
        {
            get;
            private set;
        }

        public string BrightnessDescription
        {
            get;
            private set;
        }
    }
}
