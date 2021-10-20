using Dal.Models.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Xsl;
using XML.Contracts;

namespace XML.Services
{
    public class XmlService : IXmlService
    {
        public void Transformer(string xmlSource, string xsltSource, string outputFile)
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
        public void Validation(XmlSchema xsd, string xmlSource)
        {
            XmlReaderSettings settings = new();
            settings.Schemas.Add(xsd);
            settings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create(xmlSource, settings);
            XmlDocument xmlDocument = new();
            xmlDocument.Load(reader);
        }

        public XmlSchema GetSchema(string xsdSource)
        {
            XmlTextReader reader = new(xsdSource);
            return XmlSchema.Read(reader, ValidationEventHandler);
        }


        public void Save(education education, string path)
        {
            XmlWriterSettings settings = new();
            settings.Encoding = new UTF8Encoding(true);
            settings.Indent = false;
            XmlSerializer xmlSerializer = new(typeof(education));
            using (StreamWriter textReader = new(path))
            {
                xmlSerializer.Serialize(textReader, education);
            }
        }

        public education Load(string sourceFilePath)
        {
            XmlWriterSettings settings = new();
            settings.Encoding = new UTF8Encoding(true);
            settings.Indent = false;
            XmlSerializer xmlSerializer = new(typeof(education));
            education education;
            using (TextReader textReader = new StreamReader(sourceFilePath))
            {
                education = (education)xmlSerializer.Deserialize(textReader);
            }
            return education;
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

        public void AddToXml(education toAdd, education addToo, string saveFilePath)
        {
            //maybe check if the school exist and then add lectures to it and so on all the way down to students
            foreach (educationSchool school in toAdd.School)
            {
                if (addToo.School.Any(s => s.school == school.school))
                {
                    var foundSchool = addToo.School.SingleOrDefault(s => s.school == school.school);
                    foreach (var lecture in school.lectures)
                    {
                        if (foundSchool.lectures.Any(l => l.@class == lecture.@class))
                        {

                            var foundLecture = foundSchool.lectures.SingleOrDefault(l => l.@class == lecture.@class);
                            foreach (var student in lecture.student)
                            {
                                if (foundLecture.student.Any(s => s.firstName == student.firstName && s.lastName == student.lastName))
                                {
                                    //what to do 
                                }
                                else
                                {
                                    var list = foundLecture.student.ToList();
                                    list.Add(student);
                                    foundLecture.student = list.ToArray();
                                }
                            }

                        }
                        else
                        {
                            var list = foundSchool.lectures.ToList();
                            list.Add(lecture);
                            foundSchool.lectures = list.ToArray();
                        }

                    }
                }
                else
                {
                    var list = addToo.School.ToList();
                    list.Add(school);
                    addToo.School = list.ToArray();
                }

            }

        }
    }
}
