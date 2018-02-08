using System;
using System.Collections.Generic;
using System.Xml;

namespace ReadXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlParser parser = new XmlParser("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            CurrencyWriter writer = new CurrencyWriter();
            writer.WriteToFile(parser.ParseXml(),true);
            writer.WriteToFile(parser.ParseXml(),true);
            writer.WriteToFile(parser.ParseXml(),true);
            Console.ReadKey();
        }
    }
}
