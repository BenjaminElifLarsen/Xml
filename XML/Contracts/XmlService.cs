using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace XML.Contracts
{
    public interface IXmlService
    {
        void Transformer(string xmlSource, string xsltSource, string outputFile);
        void Validation(XmlSchema xsd, string xmlSource);
        XmlSchema GetSchema(string xsdSource);

    }
}
