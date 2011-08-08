using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class VideoCard : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Type = reader["type"];
            Brand = reader["brand"];
            SocketType = reader["socket"];
            VramInMB = int.Parse(reader["vram"]);
            Cooling = reader["cooling"];
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
