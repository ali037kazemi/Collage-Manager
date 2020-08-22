using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    /// <summary>
    /// کلاسی برای نمایش اطلاعات مشترک یک شخص که یک سری از کلاس ها از آن ارث بری کرده اند
    /// </summary>
    public abstract class Person : ICloneable {
        /// <summary>
        /// کد ملی
        /// </summary>
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
