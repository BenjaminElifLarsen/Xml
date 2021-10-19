using System;
using XML.Contracts;
using XML.Services;

namespace XsltTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            IXmlService xml = new XmlService();
            try
            {
                string path = Console.ReadLine() + ".xml";
                xml.Validation(xml.GetSchema("TechCollage.xsd"), path);
                xml.Transformer(path, "TechCollage.xslt", "outputTechCollage.html");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
