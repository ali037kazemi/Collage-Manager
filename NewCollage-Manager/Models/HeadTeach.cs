using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class HeadTeach : ICloneable {
        public int PersonelID { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string StudyField { get; set; }

        public HeadTeach(string nationalCode,
                         string name, string family, string fatherName,
                         string phoneNumber, string address, string studyField)
        {
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            FatherName = fatherName;
            PhoneNumber = phoneNumber;
            Address = address;
            StudyField = studyField;

            Students = new List<Student>();
            Courses = new List<Course>();
        }

        public HeadTeach(int id, string nationalCode, string name,
                         string family, string fatherName,
                         string phoneNumber, string address, string studyField)
        {
            PersonelID = id;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            FatherName = fatherName;
            PhoneNumber = phoneNumber;
            Address = address;
            StudyField = studyField;

            Students = new List<Student>();
            Courses = new List<Course>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"HeadTeach({PersonelID} : {Name} {Family})";
        }

        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
    }
}
