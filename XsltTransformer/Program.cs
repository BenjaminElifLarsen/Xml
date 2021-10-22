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

                // Load main file, validate, and transform it to html.
                var data = xml.Load(path);
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), path); //does not validate namespace it seems
                xml.Transformer(path, "../../../../XML/XSLT/SchoolDisplay.xslt", "XmlOld.html");

                // Load second file, validate, and update the main file.
                var data2 = xml.Load("XML/" + "ToAdd" + ".xml");
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), "XML/" + "ToAdd" + ".xml");
                xml.UpdateXML(data2, data, "XML/" + "schoolNew" + ".xml");

                // Load the last file, validate, and add its data to the main file. No data is removed.
                var data3 = xml.Load("XML/" + "More" + ".xml");
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), "XML/" + "More" + ".xml");
                xml.UpdateXML(data3, data, "XML/" + "schoolNew" + ".xml", false);

                // Save the main data into a new file, validate it, and then transfor it. 
                xml.Save(data, "XML/" + "schoolNew" + ".xml");
                xml.Validation(xml.GetSchema("XSD/Education.xsd"), "XML/" + "schoolNew" + ".xml");
                xml.Transformer("XML/" + "schoolNew" + ".xml", "../../../../XML/XSLT/SchoolDisplay.xslt", "XmlNew.html");
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
