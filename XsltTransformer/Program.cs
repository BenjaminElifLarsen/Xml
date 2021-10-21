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
                string path = "XML/"+"Newest"/*Console.ReadLine()*/ + ".xml";
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), path); //does not validate namespace it seems
                var data = xml.Load(path);
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), "XML/" + "Newest" + ".xml");
                xml.Transformer(path, "../../../../XML/XSLT/SchoolDisplay.xslt", "table2.html");
                var data2 = xml.Load("XML/" + "ToAdd" + ".xml");
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), "XML/" + "ToAdd" + ".xml");
                xml.UpdateXML(data2, data, "XML/" + "schoolNew" + ".xml");
                xml.Save(data, "XML/" + "schoolNew" + ".xml");
                xml.Transformer("XML/" + "schoolNew" + ".xml", "../../../../XML/XSLT/SchoolDisplay.xslt", "table.html");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
            //Console.ReadLine();
        }
    }

}
