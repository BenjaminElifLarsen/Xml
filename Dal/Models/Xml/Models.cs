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
    public partial class education
    {

        private educationSchool[] schoolField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("School")]
        public educationSchool[] School
        {
            get
            {
                return this.schoolField;
            }
            set
            {
                this.schoolField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class educationSchool
    {

        private string schoolField;

        private educationSchoolLectures[] lecturesField;

        /// <remarks/>
        public string school
        {
            get
            {
                return this.schoolField;
            }
            set
            {
                this.schoolField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lectures")]
        public educationSchoolLectures[] lectures
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
    public partial class educationSchoolLectures
    {

        private string roomField;

        private educationSchoolLecturesStudent[] studentField;

        private string teacherField;

        private string classField;

        private bool isTaughtField;

        /// <remarks/>
        public string room
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
        [System.Xml.Serialization.XmlElementAttribute("student")]
        public educationSchoolLecturesStudent[] student
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

        /// <remarks/>
        public string teacher
        {
            get
            {
                return this.teacherField;
            }
            set
            {
                this.teacherField = value;
            }
        }

        /// <remarks/>
        public string @class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }

        /// <remarks/>
        public bool isTaught
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/Education.xsd")]
    public partial class educationSchoolLecturesStudent
    {

        private string firstNameField;

        private string lastNameField;

        private sbyte gradeField;

        /// <remarks/>
        public string firstName
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
        public string lastName
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
        public sbyte grade
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


}
