using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class Student : ICloneable {
        public int StudentID { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public Int16 EntryYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

        // added
        public string Field { get; set; }
        public string Grade { get; set; }
        public int HeadTeachID { get; set; }
        //

        public Student(string nationalCode, string name, string family, string fatherName,
                       Int16 entryYear, string phoneNumber, string address,
                       string postalCode, string field, string grade, int headID)
        {
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            FatherName = fatherName;
            EntryYear = entryYear;
            PhoneNumber = phoneNumber;
            Address = address;
            PostalCode = postalCode;
            Field = field;
            Grade = grade;
            HeadTeachID = headID;

            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }
        public Student(int id, string nationalCode, string name, string family, string fatherName,
                       Int16 entryYear, string phoneNumber, string address,
                       string postalCode, string field, string grade, int headID)
        {
            StudentID = id;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            FatherName = fatherName;
            EntryYear = entryYear;
            PhoneNumber = phoneNumber;
            Address = address;
            PostalCode = postalCode;
            Field = field;
            Grade = grade;
            HeadTeachID = headID;

            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"Student({StudentID}) : {Name} {Family} ";
        }

        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
    }
}
