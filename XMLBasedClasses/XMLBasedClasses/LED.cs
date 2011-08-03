using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class LED
    {
        public LED(XmlAttributeCollection attributes)
        {
            Color = attributes[0].InnerXml.ToString();
            BrightnessDescription = attributes[1].InnerXml.ToString();
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
