using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class Processor
    {
        public Processor(XmlAttributeCollection attributes)
        {
            Name = attributes[0].InnerXml.ToString();
            Brand = attributes[1].InnerXml.ToString();
            Socket = attributes[2].InnerXml.ToString();
            SpeedInGhz = decimal.Parse(attributes[3].InnerXml);
            Cooling = attributes[4].InnerXml.ToString();
        }

        public string Name
        {
            get;
            private set;
        }

        public string Brand
        {
            get;
            private set;
        }

        public string Socket
        {
            get;
            private set;
        }

        public decimal SpeedInGhz
        {
            get;
            private set;
        }

        public string Cooling
        {
            get;
            set;
        }
    }
}
