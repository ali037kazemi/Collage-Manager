using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public static class SqlServer {

        private static SqlConnection connection =
            new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        /*public static void CreateCourseTable()
        {
            string queryString =
                    "create table Courses(" +
                        "CourseID int identity(101, 1) PRIMARY KEY," +
                        "Title nvarchar(50) not null, " +
                        "Credit tinyInt not null," +
                        "CreditType bit not null," + // True for takhasosi, False for omumi
                        "HeadTeachID int not null FOREIGN KEY (HeadTeachID) REFERENCES HeadTeachs(PersonelID)" +
                    ");";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Courses table created Successfully");
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
        public static void InsertCourse(Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =

                    "insert into Courses " +
                    "(" +
                            "Title," +
                            "Credit," +
                            "CreditType," +
                            "HeadTeachID" +
                    ") " +
                    "values" +
                    "(" +
                            $"N'{c.Title}', " +
                            $"{c.Credit}, " +
                            $"{type}," +
                            $"{c.HeadTeachID}" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into Courses table Successfully");
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
        public static void DeleteCourse(int id)
        {
            string queryString =
                     $"delete from Courses where CourseID = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Courses deleted Successfully");
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
        public static void UpdateCourse(int id, Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =
                     $"update Courses set " +
                        $"Title = N'{c.Title}', " +
                        $"Credit = {c.Credit}, " +
                        $"CreditType = {type}," +
                        $"HeadTeachID = {c.HeadTeachID}" +
                     $"where CourseID = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Courses update Successfully");
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
        public static List<Course> SelectCourse(int id)
        {
            string queryString =
                    $"select * from Courses where CourseID = {id}";

            List<Course> courses = new List<Course>();
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
                    courses.Add(new Course(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        (byte)row.ItemArray[2], (bool)row.ItemArray[3], (int)row.ItemArray[4]));
                }

                // Displaying a message
                Console.WriteLine("Courses selected Successfully");
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

            return courses;
        }*/

        /*public static void DropHeadTeachTable()
        {
            string queryString =
                    "drop table HeadTeachs";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs table deleted Successfully");
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
        public static void CreateHeadTeachTable()
        {
            string queryString =
                    "create table HeadTeachs(" +
                        "PersonelID int identity(2001, 1)  PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "StudyField nvarchar(150)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs table created Successfully");
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
        public static void InsertHeadTeach(HeadTeach ht)
        {
            string queryString =

                    "insert into HeadTeachs " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "PhoneNumber," +
                            "Address," +
                            "StudyField" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{ht.NationalCode}', " +
                            $"N'{ht.Name}', " +
                            $"N'{ht.Family}', " +
                            $"N'{ht.FatherName}', " +
                            $"'{ht.PhoneNumber}', " +
                            $"N'{ht.Address}', " +
                            $"N'{ht.StudyField}'" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into HeadTeachs table Successfully");
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
        public static void DeleteHeadTeach(int id)
        {
            string queryString =
                     $"delete from HeadTeachs where PersonelID = {id}";
            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs deleted Successfully");
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
        public static void UpdateHeadTeach(int id, HeadTeach ht)
        {
            string queryString =
                     $"update HeadTeachs set " +
                        $"NationalCode = '{ht.NationalCode}', " +
                        $"Name = N'{ht.Name}', " +
                        $"Family = N'{ht.Family}', " +
                        $"FatherName = N'{ht.FatherName}', " +
                        $"PhoneNumber = '{ht.PhoneNumber}', " +
                        $"Address = N'{ht.Address}', " +
                        $"StudyField = N'{ht.StudyField}'" +
                     $"where PersonelID = {id}";
            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs update Successfully");
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
        public static List<HeadTeach> SelectHeadTeach(int id)
        {
            string queryString =
                    $"select * from HeadTeachs where PersonelID = {id}";

            List<HeadTeach> headTeachs = new List<HeadTeach>();
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
                    headTeachs.Add(new HeadTeach(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        row.ItemArray[2].ToString(), row.ItemArray[3].ToString(),
                        row.ItemArray[4].ToString(), row.ItemArray[5].ToString(),
                        row.ItemArray[6].ToString(), row.ItemArray[7].ToString()));
                }

                // Displaying a message
                Console.WriteLine("HeadTeachs selected Successfully");
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

            return headTeachs;
        }*/
    }
}
