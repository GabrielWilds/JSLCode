using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class LED : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        
        public void ReadXml(XmlReader reader)
        {
            Color = reader["color"];
            BrightnessDescription = reader["brightness"];
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
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
