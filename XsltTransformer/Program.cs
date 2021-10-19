using System;
using XML;

namespace XsltTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transform");
            Xslt.Transformer("Book.xml", "XSLT.xslt", "output.xml");
            Console.WriteLine("Validation");
            Xslt.Validation(Xslt.GetSchema("TechCollage.xsd"), "root.xml");
        }
    }

}
