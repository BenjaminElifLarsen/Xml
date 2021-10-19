using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace XML
{
    public class Xslt
    {
        public static void Transformer(string xmlSource, string xsltSource, string outputFile)
        {
            XslCompiledTransform xslt = new(true);
            xslt.Load(xsltSource);
            FileStream outPutStream = new(outputFile, FileMode.Create);
            xslt.Transform(xmlSource, null, outPutStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xsd"></param>
        /// <param name="xmlSource"></param>
        /// <exception cref="XmlSchemaValidationException"></exception>
        public static void Validation(XmlSchema xsd, string xmlSource)
        {
            XmlReaderSettings settings = new();
            settings.Schemas.Add(xsd);
            settings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create(xmlSource, settings);
            XmlDocument xmlDocument = new();
            xmlDocument.Load(reader);
        }

        public static XmlSchema GetSchema(string xsdSource)
        {
            XmlTextReader reader = new(xsdSource);
            return XmlSchema.Read(reader, ValidationEventHandler);
        }


        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    throw new Exception(e.Message);

                case XmlSeverityType.Warning:
                    throw new Exception(e.Message);
            }
        }
    }
}
