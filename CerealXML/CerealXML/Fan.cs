using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class Fan : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            SizeInMM = int.Parse(reader["size"]);
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public LED Led
        {
            get;
            set;
        }

        public int SizeInMM
        {
            get;
            private set;
        }

        public bool HasLED
        {
            get { return _hasLED; }
            set { _hasLED = value; }
        }

        bool _hasLED = false;
    }
}
