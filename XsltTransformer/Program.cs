using System;
using XML.Contracts;
using XML.Services;

namespace XsltTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transform");
            IXmlService xml = new XmlService();
            xml.Transformer("Book.xml", "XSLT.xslt", "output.xml");
            Console.WriteLine("Validation");
            try
            {
                xml.Validation(xml.GetSchema("TechCollage.xsd"), "root.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            xml.Transformer("root.xml", "TechCollage.xslt", "outputTechCollage.html");
        }
    }

}
