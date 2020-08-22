using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {

    /// <summary>
    /// A class for representing corses that are prerequisites(پیش نیاز) for other corses
    /// </summary>
    public class PrerequisitesCourse {
        public int MainCourseId { get; set; }
        public int PrerequisitesCourseId { get; set; }

        public PrerequisitesCourse(int mainId, int preId)
        {
            MainCourseId = mainId;
            PrerequisitesCourseId = preId;
        }
    }
}
