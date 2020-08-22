using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {

    /// <summary>
    /// A class for representing multi-to-multi relation between course and teacher.
    /// in other words a table for existing courses that a student can take them
    /// </summary>
    public class ExistingCourse {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public ExistingCourse(int teacherId, int courseId)
        {
            TeacherId = teacherId;
            CourseId = courseId;
        }
    }
}
