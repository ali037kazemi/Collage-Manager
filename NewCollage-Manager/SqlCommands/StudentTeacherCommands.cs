using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class StudentTeacherCommands {

        private static SqlConnection connection =
           new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void CreateStudentTeacherTable()
        {
            string queryString =
                    "create table StudentTeachers(" +
                        "StudentID int not null," +
                        "TeacherID int not null," +

                        "FOREIGN KEY (TeacherID) REFERENCES Teachers(PersonelID)," +
                        "FOREIGN KEY (StudentID) REFERENCES Students(StudentID)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("StudentTeachers table created Successfully");
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
        public static void InsertStudentTeacher(StudentTeacher st)
        {
            string queryString =

                    "insert into StudentTeachers " +
                    "(" +
                            "StudentID," +
                            "TeacherID" +
                    ") " +
                    "values" +
                    "(" +
                            $"{st.StudentID}, " +
                            $"{st.TeacherID} " +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into StudentTeachers table Successfully");
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
