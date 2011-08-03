using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class DiskDrive
    {
        public DiskDrive(XmlAttributeCollection attributes)
        {
            Type = attributes[0].InnerXml.ToString();
            Brand = attributes[1].InnerXml.ToString();
            Quality = attributes[2].InnerXml.ToString();
        }

        public string Type
        {
            get;
            private set;
        }

        public string Brand
        {
            get;
            private set;
        }

        public string Quality
        {
            get;
            private set;
        }
    }
}
