using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class Processor : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Name = reader["name"];
            Brand = reader["brand"];
            Socket = reader["socket"];
            SpeedInGhz = decimal.Parse(reader["speed"]);
            Cooling = reader["cooling"];
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
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
