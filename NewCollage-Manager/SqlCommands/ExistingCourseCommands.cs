using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class ExistingCourseCommands {

        private static SqlConnection connection =
           new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void CreateExistingCourseTable()
        {
            string queryString =
                    "create table ExistingCourses(" +
                        "TeacherID int not null," +
                        "CourseID int not null," +

                        //"CONSTRAINT FK_Exsting_Teacher FOREIGN KEY (TeacherID) REFERENCES Teachers(PersonelID)," +
                        "CONSTRAINT FK_Exsting_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("ExistingCourses table created Successfully");
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
        public static void InsertExistingCourse(ExistingCourse ec)
        {
            string queryString =

                    "insert into ExistingCourses " +
                    "(" +
                            "TeacherID," +
                            "CourseID" +
                    ") " +
                    "values" +
                    "(" +
                            $"{ec.TeacherID}, " +
                            $"{ec.CourseID} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into ExistingCourses table Successfully");
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
