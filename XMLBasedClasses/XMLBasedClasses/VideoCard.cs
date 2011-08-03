using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class VideoCard
    {
        public VideoCard(XmlAttributeCollection attributes)
        {
            Type = attributes[0].InnerXml.ToString();
            Brand = attributes[1].InnerXml.ToString();
            VramInMB = int.Parse(attributes[2].InnerXml);
            SocketType = attributes[3].InnerXml.ToString();
            Cooling = attributes[4].InnerXml.ToString();
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

        public int VramInMB
        {
            get;
            private set;
        }

        public string SocketType
        {
            get;
            private set;
        }

        public string Cooling
        {
            get;
            private set;
        }

    }
}
