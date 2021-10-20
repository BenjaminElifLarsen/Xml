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
                string path = "XML/"+"school"/*Console.ReadLine()*/ + ".xml";
                //xml.Validation(xml.GetSchema("TechCollage.xsd"), path);
                //xml.Transformer(path, "TechCollage.xslt", "outputTechCollage.html");
                xml.Validation(xml.GetSchema("XSD/School.xsd"), path); //does not validate namespace it seems
                var data = xml.Load(path);
                xml.Validation(xml.GetSchema("XSD/School.xsd"), "XML/" + "new" + ".xml");
                var data2 = xml.Load("XML/" + "new" + ".xml");
                data.School[0].lectures[0].teacher = "Bob Ross";
                xml.AddToXml(data2, data, "XML/" + "schoolNew" + ".xml");
                xml.Save(data, "XML/" + "schoolNew" + ".xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

}
