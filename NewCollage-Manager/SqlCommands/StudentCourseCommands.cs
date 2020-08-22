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
    /// A class for quering on StudentCourses(دروس اخذ شده توسط دانشجو) table
    /// </summary>
    public class StudentCourseCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public StudentCourseCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساخت جدول دروس اخذ شده توسط دانشجو
        /// </summary>
        public void CreateStudentCourseTable()
        {
            string queryString =
                    "create table StudentCourses(" +
                        "StudentId int not null," +
                        "CourseId int not null," +

                        "CONSTRAINT FK_Student_SC FOREIGN KEY (StudentId) REFERENCES Students(StudentId)," +
                        "CONSTRAINT FK_Course_SC FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("StudentCourses table created Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// اضافه کردن یک ردیف در جدول دروس اخذ شده توسط دانشجو
        /// </summary>
        /// <param name="sc">درس و دانشجو مورد نظر</param>
        public void InsertStudentCourse(StudentCourse sc)
        {
            string queryString =

                    "insert into StudentCourses " +
                    "(" +
                            "StudentId," +
                            "CourseId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{sc.StudentId}, " +
                            $"{sc.CourseId} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into StudentCourses table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
