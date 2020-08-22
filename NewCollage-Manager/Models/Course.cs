using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    public class Course : ICloneable {
        public int CourseId { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// تعداد واحد
        /// </summary>
        public byte Credit { get; set; }
        /// <summary>
        /// True value is for takhasosi and False value is for omumi
        /// </summary>
        public bool CreditType { get; set; } // True for takhasosi, False for omumi
        /// <summary>
        /// آیدی مسول آموزشی که این درس را ارایه میدهد
        /// </summary>
        public int HeadTeachId { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        /// <summary>
        /// پیشنیازهای درس
        /// </summary>
        public List<Course> PrerequisitesCourses { get; set; }

        public Course(string title, byte credit, bool creditType, int headId)
        {
            Title = title;
            Credit = credit;
            CreditType = creditType;
            HeadTeachId = headId;

            Students = new List<Student>();
            Teachers = new List<Teacher>();
            PrerequisitesCourses = new List<Course>();
        }
        public Course(int id, string title, byte credit, bool creditType, int headId)
            : this(title, credit, creditType, headId)
        {
            CourseId = id;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"Course({CourseId}) : {Title}, {Credit}, {CreditType}";
        }
    }
}
