using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    /// <summary>
    /// دانشجو که از کلاس Person ارث بری کرده است
    /// </summary>
    public class Student : Person {
        public int StudentId { get; set; }
        /// <summary>
        /// سال ورود به دانشگاه
        /// برای مثال 1397 
        /// </summary>
        public Int16 EntryYear { get; set; }
        /// <summary>
        /// کد پستی
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// رشته تحصیلی
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// مقطع تحصیلی
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// آیدی مسول آموزش رشته مورد نظر
        /// </summary>
        public int HeadTeachId { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationalCode"></param>
        /// <param name="name"></param>
        /// <param name="family"></param>
        /// <param name="fatherName"></param>
        /// <param name="entryYear">سال ورود به دانشگاه</param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="postalCode">کد پستی</param>
        /// <param name="field">رشته تحصیلی</param>
        /// <param name="grade">مقطع تحصیلی</param>
        /// <param name="headId">آیدی مسول آموزش رشته تحصیلی</param>
        public Student(string nationalCode, string name, string family, string fatherName,
                       Int16 entryYear, string phoneNumber, string address,
                       string postalCode, string field, string grade, int headId)
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
            HeadTeachId = headId;

            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nationalCode"></param>
        /// <param name="name"></param>
        /// <param name="family"></param>
        /// <param name="fatherName"></param>
        /// <param name="entryYear">سال ورود به دانشگاه</param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="postalCode">کد پستی</param>
        /// <param name="field">رشته تحصیلی</param>
        /// <param name="grade">مقطع تحصیلی</param>
        /// <param name="headId">آیدی مسول آموزش رشته تحصیلی</param>
        public Student(int id, string nationalCode, string name, string family, string fatherName,
                       Int16 entryYear, string phoneNumber, string address,
                       string postalCode, string field, string grade, int headId)
        {
            StudentId = id;
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
            HeadTeachId = headId;

            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }

        public override string ToString()
        {
            return $"Student({StudentId}) : {Name} {Family} ";
        }
    }
}
