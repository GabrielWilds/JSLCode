using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class Fan
    {
        public Fan(XmlAttributeCollection attributes)
        {
            SizeInMM = int.Parse(attributes[0].InnerXml);
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
