using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class Motherboard
    {
        public Motherboard(XmlAttributeCollection attributes)
        {
            Brand = attributes[0].InnerXml.ToString();
            Size = attributes[1].InnerXml.ToString();
            CPUSocket = attributes[2].InnerXml.ToString();
            RAMType = attributes[3].InnerXml.ToString();
            RAMSlots = int.Parse(attributes[4].InnerXml);
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
