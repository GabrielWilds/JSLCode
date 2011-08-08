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

            reader.ReadToFollowing("motherboard");
            Mobo = new Motherboard();
            Mobo.ReadXml(reader);

            reader.ReadToFollowing("processor");
            CPU = new Processor();
            CPU.ReadXml(reader);

            reader.ReadToFollowing("ram");
            Ram = new RAM();
            Ram.ReadXml(reader);

            reader.ReadToFollowing("videocard");
            Videocard = new VideoCard();
            Videocard.ReadXml(reader);

            reader.ReadToFollowing("diskdrive");
            Diskdrive = new DiskDrive();
            Diskdrive.ReadXml(reader);

            reader.ReadToFollowing("fans");
            while (true)
            {
                reader.Read();
                if (reader.Name == "fan")
                {
                    Fan fan = new Fan();
                    fan.ReadXml(reader);
                    AddFan(fan);
                }
                else if (reader.Name == "LED")
                {
                    Fans[Fans.Count - 1].HasLED = true;
                    LED led = new LED();
                    led.ReadXml(reader);
                    Fans[Fans.Count - 1].Led = led;
                    reader.Read();
                }

                if (reader.EOF)
                    break;
            }
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
