using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    public class Case : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Brand = reader["brand"];
            Size = reader["size"];
            Color = reader["color"];
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

        public string Color
        {
            get;
            private set;
        }

        public Motherboard Mobo
        {
            get;
            set;
        }

        public Processor CPU
        {
            get;
            set;
        }

        public VideoCard Videocard
        {
            get;
            set;
        }

        public RAM Ram
        {
            get;
            set;
        }

        public DiskDrive Diskdrive
        {
            get;
            set;
        }

        public List<Fan> Fans
        {
            get
            {
                return fans;
            }
        }

        List<Fan> fans = new List<Fan>();

        public void AddFan(Fan fan)
        {
            fans.Add(fan);
        }
    }
}
