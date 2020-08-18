using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class StudentCourse {
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public StudentCourse(int studentID, int courseID)
        {
            StudentID = studentID;
            CourseID = courseID;
        }
    }
}
