using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace ReadXML
{
    class XmlParser
    {
        private string xmlURL; 
        private List<string> currencies;

        public XmlParser(string xmlURL)
        {
            this.xmlURL = xmlURL;
        }

        public List<string> ParseXml()
        {
            currencies = new List<string>();
            try
            {
                XmlTextReader reader = new XmlTextReader(xmlURL);
                while (reader.Read())
                {
                    string concateratedCurrency = null;
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "currency") concateratedCurrency = reader.Value;
                        if (reader.Name == "rate") concateratedCurrency = concateratedCurrency + " -- " + reader.Value;
                    }
                    if (concateratedCurrency != null) currencies.Add(concateratedCurrency);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return currencies;
        }
    }
}
