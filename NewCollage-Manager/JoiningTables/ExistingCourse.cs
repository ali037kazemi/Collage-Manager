using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class ExistingCourse {
        public ExistingCourse(int teacherID, int courseID)
        {
            TeacherID = TeacherID;
            CourseID = courseID;
        }

        public int TeacherID { get; set; }
        public int CourseID { get; set; }
    }
}
