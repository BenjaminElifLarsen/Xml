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
            try
            {
                Xslt.Validation(Xslt.GetSchema("TechCollage.xsd"), "root.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Xslt.Transformer("root.xml", "TechCollage.xslt", "outputTechCollage.html");
        }
    }

}
