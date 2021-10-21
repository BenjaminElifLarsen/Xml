using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models.Xml
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/Education.xsd", IsNullable = false)]
    public partial class Education
    {

        private EducationSchools[] schoolsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Schools")]
        public EducationSchools[] Schools
        {
            get
            {
                return this.schoolsField;
            }
            set
            {
                this.schoolsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class EducationSchools
    {

        private string nameField;

        private int idField;

        private EducationSchoolsTeachers[] teachersField;

        private EducationSchoolsTeams[] teamsField;

        private EducationSchoolsLectures[] lecturesField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Teachers")]
        public EducationSchoolsTeachers[] Teachers
        {
            get
            {
                return this.teachersField;
            }
            set
            {
                this.teachersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Teams")]
        public EducationSchoolsTeams[] Teams
        {
            get
            {
                return this.teamsField;
            }
            set
            {
                this.teamsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Lectures")]
        public EducationSchoolsLectures[] Lectures
        {
            get
            {
                return this.lecturesField;
            }
            set
            {
                this.lecturesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class EducationSchoolsTeachers
    {

        private byte idField;

        private string nameField;

        /// <remarks/>
        public byte Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class EducationSchoolsTeams
    {

        private byte idField;

        private string nameField;

        private EducationSchoolsTeamsLectures[] lecturesField;

        private EducationSchoolsTeamsStudent[] studentField;

        /// <remarks/>
        public byte Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Lectures")]
        public EducationSchoolsTeamsLectures[] Lectures
        {
            get
            {
                return this.lecturesField;
            }
            set
            {
                this.lecturesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Student")]
        public EducationSchoolsTeamsStudent[] Student
        {
            get
            {
                return this.studentField;
            }
            set
            {
                this.studentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class EducationSchoolsTeamsLectures
    {

        private int idField;

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class EducationSchoolsTeamsStudent
    {

        private string idField;

        private string firstNameField;

        private string lastNameField;

        private sbyte gradeField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public sbyte Grade
        {
            get
            {
                return this.gradeField;
            }
            set
            {
                this.gradeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class EducationSchoolsLectures
    {

        private int idField;

        private string roomField;

        private byte teacherIdField;

        private string nameField;

        private bool isTaughtField;

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Room
        {
            get
            {
                return this.roomField;
            }
            set
            {
                this.roomField = value;
            }
        }

        /// <remarks/>
        public byte TeacherId
        {
            get
            {
                return this.teacherIdField;
            }
            set
            {
                this.teacherIdField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public bool IsTaught
        {
            get
            {
                return this.isTaughtField;
            }
            set
            {
                this.isTaughtField = value;
            }
        }
    }






}
