using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    /// <summary>
    /// استاد که از کلاس Person ارث بری کرده است
    /// </summary>
    public class Teacher : Person {
        public int TeacherId { get; set; }
        /// <summary>
        /// مدرک تحصیلی
        /// </summary>
        public string Degree { get; set; }
        public List<Student> Students { get; set; }
        /// <summary>
        /// دروس ارایه شده توسط استاد
        /// </summary>
        public List<Course> Courses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationalCode"></param>
        /// <param name="name"></param>
        /// <param name="family"></param>
        /// <param name="fatherName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="degree">مدرک تحصیلی</param>
        public Teacher(string nationalCode, string name, string family,
                       string fatherName, string phoneNumber, string address,
                       string degree)
        {
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            FatherName = fatherName;
            PhoneNumber = phoneNumber;
            Address = address;
            Degree = degree;

            Students = new List<Student>();
            Courses = new List<Course>();
        }

        public override string ToString()
        {
            return $"Teacher({TeacherId}) : {Name} {Family}";
        }
    }
}
