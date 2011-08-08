using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class DiskDrive : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Type = reader["type"];
            Brand = reader["brand"];
            Quality = reader["quality"];
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
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
