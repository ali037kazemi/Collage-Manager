using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class StudentCourseCommands {

        private static SqlConnection connection =
           new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void CreateStudentCourseTable()
        {
            string queryString =
                    "create table StudentCourses(" +
                        "StudentID int not null," +
                        "CourseID int not null," +

                        "CONSTRAINT FK_Student_SC FOREIGN KEY (StudentID) REFERENCES Students(StudentID)," +
                        "CONSTRAINT FK_Course_SC FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("StudentCourses table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
        public static void InsertStudentCourse(StudentCourse sc)
        {
            string queryString =

                    "insert into StudentCourses " +
                    "(" +
                            "StudentID," +
                            "CourseID" +
                    ") " +
                    "values" +
                    "(" +
                            $"{sc.StudentID}, " +
                            $"{sc.CourseID} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into StudentCourses table Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
    }
}
