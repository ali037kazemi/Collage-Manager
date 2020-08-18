using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class PrerequisitesCourse {
        public int MainCourseID { get; set; }
        public int PrerequisitesCourseID { get; set; }

        public PrerequisitesCourse(int mainID, int preID)
        {
            MainCourseID = mainID;
            PrerequisitesCourseID = preID;
        }
    }
}
