using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class TeacherCommands {

        private static SqlConnection connection =
            new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void CreateTeacherTable()
        {
            string queryString =
                    "create table Teachers(" +
                        "PersonelID int identity(1001, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "Degree nvarchar(150)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Teachers table created Successfully");
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
        public static void InsertTeacher(Teacher st)
        {
            string queryString =

                    "insert into Teachers " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "PhoneNumber," +
                            "Address," +
                            "Degree" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{st.NationalCode}', " +
                            $"N'{st.Name}', " +
                            $"N'{st.Family}', " +
                            $"N'{st.FatherName}', " +
                            $"'{st.PhoneNumber}', " +
                            $"N'{st.Address}', " +
                            $"N'{st.Degree}'" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into Teachers table Successfully");
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
        public static void DeleteTeacher(int id)
        {
            string queryString =
                    $"delete from Teachers where PersonelID = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Teachers deleted Successfully");
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
        public static void UpdateTeacher(int id, Teacher t)
        {
            string queryString =
                    $"update Teachers set " +
                        $"NationalCode = '{t.NationalCode}', " +
                        $"Name = N'{t.Name}', " +
                        $"Family = N'{t.Family}', " +
                        $"FatherName = N'{t.FatherName}', " +
                        $"PhoneNumber = '{t.PhoneNumber}', " +
                        $"Address = N'{t.Address}', " +
                        $"Degree = N'{t.Degree}'" +
                    $"where PersonelID = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Teachers update Successfully");
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
        public static List<Teacher> SelectTeacher(int id)
        {
            string queryString =
                    $"select * from Teachers where PersonelID = {id}";

            List<Teacher> teachers = new List<Teacher>();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                // Opening Connection  
                connection.Open();

                adapter.SelectCommand = new SqlCommand(queryString, connection);

                adapter.Fill(ds);

                DataTable sTable = ds.Tables[0];
                for (int i = 0; i < sTable.Rows.Count; i++)
                {
                    DataRow row = sTable.Rows[i];
                    Teacher teacher = new Teacher(
                            row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                            row.ItemArray[3].ToString(), row.ItemArray[4].ToString(),
                            row.ItemArray[5].ToString(), row.ItemArray[6].ToString(),
                            row.ItemArray[7].ToString());
                    teacher.PersonelID = (int)row.ItemArray[0];
                    teachers.Add(teacher);
                }

                // Displaying a message
                Console.WriteLine("Teachers selected Successfully");
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

            return teachers;
        }
    }
}
