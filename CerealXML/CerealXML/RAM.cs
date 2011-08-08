using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class RAM : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            SlotType = reader["type"];
            NumSticks = int.Parse(reader["stickcount"]);
            CapacityInGB = int.Parse(reader["totalcapacity"]);
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
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
