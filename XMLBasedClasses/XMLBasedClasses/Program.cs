using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLBasedClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("C:\\computer.xml");

            XmlNode node = xmldoc.FirstChild;

            ReadXMLToData(xmldoc);
            //XmlElement fan = xmldoc.CreateElement("fan");
            //fan.SetAttribute("size", "120mm");
            //AddElementToXml(xmldoc.FirstChild, fan, "fan");
            //DisplayAllNodes(node);
            //xmldoc.Save("C:\\computer2.xml");
            Console.ReadKey();
        }

        static void DisplayAllNodes(XmlNode node)
        {
            foreach (XmlNode childnode in node.ChildNodes)
            {
                DisplayAllNodes(childnode);
            }
            Console.Write("Node " + node.Name.ToString());
            foreach (XmlElement element in node)
            {
                Console.Write(element.ToString() + ", ");
            }
            Console.WriteLine();
        }

        static void AddElementToXml(XmlNode node, XmlElement newElement, string targetNodeForParent)
        {
            if (node.Name == targetNodeForParent)
                node.PrependChild(newElement);
            else
            {
                for( int i = 0; i < node.ChildNodes.Count; i++)
                    AddElementToXml(node.ChildNodes[i], newElement, targetNodeForParent);
            }
        }

        static void ReadXMLToData(XmlDocument doc)
        {
            Computer computer = new Computer();
            XmlAttributeCollection attributes = doc.FirstChild.FirstChild.Attributes;
            computer.Case = new Case(attributes);
            Console.WriteLine(computer.Case.Brand + ", " + computer.Case.Size + ", " + computer.Case.Color);
        }
    }
}
