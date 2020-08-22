using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    /// <Author>Ali Kazemi</Author>
    /// <summary>
    /// A class for quering on PrerequisitesCourses(پیشنیاز های دروس) table
    /// </summary>
    public class PrerequisitesCourseCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public PrerequisitesCourseCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساختن جدول دروس و پیشنیاز های آنها
        /// </summary>
        public void CreatePrerequisitesCourseTable()
        {
            string queryString =
                    "create table PrerequisitesCourses(" +
                        "MainCourseId int not null," +
                        "PrerequisitesCourseId int not null," +

                        "CONSTRAINT FK_Main_Course FOREIGN KEY (MainCourseId) REFERENCES Courses(CourseId)," +
                        "CONSTRAINT FK_Pre_Course FOREIGN KEY (PrerequisitesCourseId) REFERENCES Courses(CourseId)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("PrerequisitesCourses table created Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// اضافه کردن ردیف در جدول دروس و پیشنیاز ها
        /// </summary>
        public void InsertPrerequisitesCourse(PrerequisitesCourse pc)
        {
            string queryString =

                    "insert into PrerequisitesCourses " +
                    "(" +
                            "MainCourseId," +
                            "PrerequisitesCourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{pc.MainCourseId}, " +
                            $"{pc.PrerequisitesCourseId} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into PrerequisitesCourses table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
