using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class PrerequisitesCourseCommands {

        private static SqlConnection connection =
           new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void CreatePrerequisitesCourseTable()
        {
            string queryString =
                    "create table PrerequisitesCourses(" +
                        "MainCourseID int not null," +
                        "PrerequisitesCourseID int not null," +

                        "CONSTRAINT FK_Main_Course FOREIGN KEY (MainCourseID) REFERENCES Courses(CourseID)," +
                        "CONSTRAINT FK_Pre_Course FOREIGN KEY (PrerequisitesCourseID) REFERENCES Courses(CourseID)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("PrerequisitesCourses table created Successfully");
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
        public static void InsertPrerequisitesCourse(PrerequisitesCourse pc)
        {
            string queryString =

                    "insert into PrerequisitesCourses " +
                    "(" +
                            "MainCourseID," +
                            "PrerequisitesCourseID" +
                    ") " +
                    "values" +
                    "(" +
                            $"{pc.MainCourseID}, " +
                            $"{pc.PrerequisitesCourseID} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into PrerequisitesCourses table Successfully");
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
