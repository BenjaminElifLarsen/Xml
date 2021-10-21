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


        public void Save(Education education, string path)
        {
            XmlWriterSettings settings = new();
            settings.Encoding = new UTF8Encoding(true);
            settings.Indent = false;
            XmlSerializer xmlSerializer = new(typeof(Education));
            using (StreamWriter textReader = new(path))
            {
                xmlSerializer.Serialize(textReader, education);
            }
        }

        public Education Load(string sourceFilePath)
        {
            XmlWriterSettings settings = new();
            settings.Encoding = new UTF8Encoding(true);
            settings.Indent = false;
            XmlSerializer xmlSerializer = new(typeof(Education));
            Education education;
            using (TextReader textReader = new StreamReader(sourceFilePath))
            {
                education = (Education)xmlSerializer.Deserialize(textReader);
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

        public void UpdateXML(Education toAdd, Education addToo, string saveFilePath)
        {
            foreach(var delete in addToo.Schools.Where(s => !toAdd.Schools.Any(ss => s.Id == ss.Id)))
            {
                var list = addToo.Schools.ToList();
                list.Remove(delete);
                addToo.Schools = list.ToArray();
            }

            foreach(var school in toAdd.Schools)
            {
                if(addToo.Schools.Any(s => s.Id == school.Id))
                {
                    var foundSchool = addToo.Schools.SingleOrDefault(s => s.Id == school.Id);

                    foreach(var delete in school.Lectures)
                    {
                        if(!foundSchool.Lectures.Any(l => l.Id == delete.Id))
                        {
                            var list = foundSchool.Lectures.ToList();
                            list.Remove(delete);
                            foundSchool.Lectures = list.ToArray();
                        }
                    }

                    foreach (var delete in foundSchool.Teachers.Where(s => !school.Teachers.Any(ss => s.Id == ss.Id)))
                    {
                        var list = foundSchool.Teachers.ToList();
                        list.Remove(delete);
                        foundSchool.Teachers = list.ToArray();
                    }

                    foreach (var team in school.Teams)
                    {
                        foreach(var delete in foundSchool.Teams.Where(s => !school.Teams.Any(ss => s.Id == ss.Id)))
                        {
                            var list = foundSchool.Teams.ToList();
                            list.Remove(delete);
                            foundSchool.Teams = list.ToArray();
                        }

                        var foundTeam = foundSchool.Teams.SingleOrDefault(t => t.Id == team.Id);
                        foreach (var delete in foundTeam.Student.Where(s => !team.Student.Any(ss => s.Id == ss.Id)))
                        {
                            var list = foundTeam.Student.ToList();
                            list.Remove(delete);
                            foundTeam.Student = list.ToArray();
                        }
                    }
                }
            }

            foreach (var school in toAdd.Schools)
            {
                if (addToo.Schools.Any(s => s.Id == school.Id))
                {
                    var foundSchool = addToo.Schools.SingleOrDefault(s => s.Id == school.Id);
                    foundSchool.Name = school.Name;
                    foreach (var team in school.Teams)
                    {
                        if(foundSchool.Teams.Any(t => t.Id == team.Id))
                        {
                            var foundTeam = foundSchool.Teams.SingleOrDefault(t => t.Id == team.Id);
                            var currentTeam = school.Teams.SingleOrDefault(t => t.Id == team.Id);
                            foreach (var student in currentTeam.Student)
                            {
                                if(foundTeam.Student.Any(s => s.Id == student.Id))
                                {
                                    var foundStudent = foundTeam.Student.SingleOrDefault(s => s.Id == student.Id);
                                    foundStudent.FirstName = student.FirstName;
                                    foundStudent.LastName = student.LastName;
                                    foundStudent.Grade = student.Grade;
                                }
                                else
                                {
                                    var list = foundTeam.Student.ToList();
                                    list.Add(student);
                                    foundTeam.Student = list.ToArray();
                                }
                            }
                            foundTeam.Name = currentTeam.Name;
                            foundTeam.Lectures = currentTeam.Lectures;
                        }
                        else
                        {
                            var list = foundSchool.Teams.ToList();
                            list.Add(team);
                            foundSchool.Teams = list.ToArray();
                        }
                    }

                    foreach(var teacher in school.Teachers)
                    {
                        if(foundSchool.Teachers.Any(t => t.Id == teacher.Id))
                        {
                            var foundTeacher = foundSchool.Teachers.SingleOrDefault(t => t.Id == teacher.Id);
                            foundTeacher.Name = teacher.Name;
                        }
                        else
                        {
                            var list = foundSchool.Teachers.ToList();
                            list.Add(teacher);
                            foundSchool.Teachers = list.ToArray();
                        }
                    }

                    foreach (var lecture in school.Lectures)
                    {
                        if (foundSchool.Lectures.Any(l => l.Id == lecture.Id))
                        {

                            var foundLecture = foundSchool.Lectures.SingleOrDefault(l => l.Id == lecture.Id);
                            foundLecture.IsTaught = lecture.IsTaught;
                            foundLecture.Name = lecture.Name;
                            foundLecture.TeacherId = lecture.TeacherId;
                            foundLecture.Room = lecture.Room;
                        }
                        else
                        {
                            var list = foundSchool.Lectures.ToList();
                            list.Add(lecture);
                            foundSchool.Lectures = list.ToArray();
                        }
                    }
                }
                else
                {
                    var list = addToo.Schools.ToList();
                    list.Add(school);
                    addToo.Schools = list.ToArray();
                }

            }

        }
    }
}
