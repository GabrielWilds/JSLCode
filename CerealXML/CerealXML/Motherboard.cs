using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class Motherboard : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Brand = reader["brand"];
            Size = reader["size"];
            CPUSocket = reader["socket"];
            RAMType = reader["ram"];
            RAMSlots = int.Parse(reader["ramslots"]);
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
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
