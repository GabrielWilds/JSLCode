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
            computer.ReadXml(reader);

            Console.ReadKey();
        }
    }
}
