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
    /// A class for quering on ExistingCourses(درس های ارایه شده توسط مسول آموزش) table
    /// </summary>
    public class ExistingCourseCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public ExistingCourseCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساخت جدول دروس ارایه شده توسط مسول آموزش
        /// </summary>
        public void CreateExistingCourseTable()
        {
            string queryString =
                    "create table ExistingCourses(" +
                        "TeacherId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Exsting_Teacher FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)," +
                        "CONSTRAINT FK_Exsting_Course FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("ExistingCourses table created Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// اضافه کردن ردیف به دروس ارایه شده
        /// </summary>
        /// <param name="ec"></param>
        public void InsertExistingCourse(ExistingCourse ec)
        {
            string queryString =

                    "insert into ExistingCourses " +
                    "(" +
                            "TeacherId," +
                            "CourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{ec.TeacherId}, " +
                            $"{ec.CourseId} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into ExistingCourses table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
