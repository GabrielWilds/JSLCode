using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class RAM
    {
        public RAM(XmlAttributeCollection attributes)
        {
            NumSticks = int.Parse(attributes[0].InnerXml);
            SlotType = attributes[1].InnerXml.ToString();
            CapacityInGB = int.Parse(attributes[2].InnerXml);
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
