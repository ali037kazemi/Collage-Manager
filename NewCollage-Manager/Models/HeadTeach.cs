using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    /// <summary>
    /// مسول آموزش که از کلاس Person ارث بری کرده است
    /// </summary>
    public class HeadTeach : Person {
        public int HeadTeachId { get; set; }
        /// <summary>
        /// رشته تحصیلی که مسول آن بخش است
        /// </summary>
        public string StudyField { get; set; }
        /// <summary>
        /// دانشج.یان رشته تحصیلی مورد نظر
        /// </summary>
        public List<Student> Students { get; set; }
        /// <summary>
        /// دروس موجود در رشته تحصیلی مورد نظر
        /// </summary>
        public List<Course> Courses { get; set; }

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
            HeadTeachId = id;
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

        public override string ToString()
        {
            return $"HeadTeach({HeadTeachId} : {Name} {Family})";
        }
    }
}
