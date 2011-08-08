using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CerealXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            settings.IgnoreProcessingInstructions = true;
            XmlReader reader = XmlReader.Create("C:\\computer.xml", settings);
            Computer computer = new Computer();

            reader.ReadToFollowing("case");
            computer.Case = new Case();
            computer.Case.ReadXml(reader);
            Console.WriteLine(computer.Case.Brand + computer.Case.Size + computer.Case.Color);

            reader.ReadToFollowing("motherboard");
            computer.Case.Mobo = new Motherboard();
            computer.Case.Mobo.ReadXml(reader);

            reader.ReadToFollowing("processor");
            computer.Case.CPU = new Processor();
            computer.Case.CPU.ReadXml(reader);

            reader.ReadToFollowing("ram");
            computer.Case.Ram = new RAM();
            computer.Case.Ram.ReadXml(reader);

            reader.ReadToFollowing("videocard");
            computer.Case.Videocard = new VideoCard();
            computer.Case.Videocard.ReadXml(reader);

            reader.ReadToFollowing("diskdrive");
            computer.Case.Diskdrive = new DiskDrive();
            computer.Case.Diskdrive.ReadXml(reader);

            reader.ReadToFollowing("fans");
            while (true)
            {
                reader.MoveToElement();
                if (reader.Name == "fan")
                {
                    Fan fan = new Fan();
                    fan.ReadXml(reader);
                    computer.Case.AddFan(fan);
                }
                else if (reader.Name == "LED")
                {
                    computer.Case.Fans[computer.Case.Fans.Count - 1].HasLED = true;
                    LED led = new LED();
                    led.ReadXml(reader);
                    computer.Case.Fans[computer.Case.Fans.Count - 1].Led = led;
                }
                else
                    break;
            }
                
            Console.ReadKey();
        }
    }
}
