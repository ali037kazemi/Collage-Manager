using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class Course : ICloneable {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public byte Credit { get; set; }
        public bool CreditType { get; set; } // True for takhasosi, False for omumi

        // added
        public int HeadTeachID { get; set; }
        //

        public Course(string title, byte credit, bool creditType, int headID)
        {
            Title = title;
            Credit = credit;
            CreditType = creditType;
            HeadTeachID = headID;

            Students = new List<Student>();
            Teachers = new List<Teacher>();
            PrerequisitesCourses = new List<Course>();
        }

        public Course(int id, string title, byte credit, bool creditType, int headID)
            : this(title, credit, creditType, headID)
        {
            CourseID = id;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"Course({CourseID}) : {Title}, {Credit}, {CreditType}";
        }

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> PrerequisitesCourses { get; set; }
    }
}
