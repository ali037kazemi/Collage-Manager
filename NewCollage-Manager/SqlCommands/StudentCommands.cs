using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class StudentCommands {

        private static SqlConnection connection =
            new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void CreateStudentTable()
        {
            string queryString =
                    "create table Students(" +
                        "StudentID int identity(99001, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "EntryYear smallInt not null check(EntryYear > 1394)," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11)," +
                        "Address nvarchar(150)," +
                        "PostalCode varchar(10) check(LEN(PostalCode) = 10)," +
                        "Field nvarchar(50) not null," +
                        "Grade nvarchar(50) not null," +
                        "HeadTeachID int not null," +

                        "CONSTRAINT FK_Student FOREIGN KEY (HeadTeachID) REFERENCES HeadTeachs(PersonelID)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Students table created Successfully");
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
        public static void InsertStudent(Student st)
        {
            string queryString =

                    "insert into Students " +
                    "(" +
                            "NationalCode," +
                            "Name," +
                            "Family," +
                            "FatherName," +
                            "EntryYear," +
                            "PhoneNumber," +
                            "Address," +
                            "PostalCode," +
                            "Field," +
                            "Grade," +
                            "HeadTeachID" +
                    ") " +
                    "values" +
                    "(" +
                            $"'{st.NationalCode}', " +
                            $"N'{st.Name}', " +
                            $"N'{st.Family}', " +
                            $"N'{st.FatherName}', " +
                            $"{st.EntryYear}, " +
                            $"'{st.PhoneNumber}', " +
                            $"N'{st.Address}', " +
                            $"'{st.PostalCode}'," +
                            $"N'{st.Field}'," +
                            $"N'{st.Grade}'," +
                            $"{st.HeadTeachID}" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into Students table Successfully");
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
        public static void DeleteStudent(int id)
        {
            string queryString =
                    $"delete from Students where StudentID = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Students deleted Successfully");
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
        public static void UpdateStudent(int id, Student st)
        {
            string queryString =
                    $"update Students set " +
                        $"NationalCode = '{st.NationalCode}', " +
                        $"Name = N'{st.Name}', " +
                        $"Family = N'{st.Family}', " +
                        $"FatherName = N'{st.FatherName}', " +
                        $"EntryYear = {st.EntryYear}, " +
                        $"PhoneNumber = '{st.PhoneNumber}', " +
                        $"Address = N'{st.Address}', " +
                        $"PostalCode = '{st.PostalCode}'," +
                        $"Field = N'{st.Field}'," +
                        $"Grade = N'{st.Grade}'," +
                        $"HeadTeachID = {st.HeadTeachID}" +
                    $" where StudentID = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                // Opening Connection  
                connection.Open();

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Students updated Successfully");
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
        public static List<Student> SelectStudent(int id)
        {
            string queryString =
                    $"select * from Students where StudentID = {id}";

            List<Student> students = new List<Student>();
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
                    students.Add(new Student(
                        (int)row.ItemArray[0], row.ItemArray[1].ToString(),
                        row.ItemArray[2].ToString(), row.ItemArray[3].ToString(),
                        row.ItemArray[4].ToString(), (Int16)row.ItemArray[5],
                        row.ItemArray[6].ToString(), row.ItemArray[7].ToString(),
                        row.ItemArray[8].ToString(), row.ItemArray[9].ToString(),
                        row.ItemArray[10].ToString(), (int)row.ItemArray[11]));
                }

                // Displaying a message
                Console.WriteLine("Students selected Successfully");
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

            return students;

            #region DataReader
            //string queryString =
            //        $"select * from Students where StudentID = {id}";

            //List<Student> students = new List<Student>();
            //try
            //{
            //    SqlCommand cm = new SqlCommand(queryString, connection);

            //    // Opening Connection  
            //    connection.Open();

            //    // Executing the SQL query 
            //    SqlDataReader sdr = cm.ExecuteReader();
            //    if (sdr.HasRows)
            //    {
            //        while (sdr.Read())
            //        {
            //            //students.Add(new Student(
            //            //                         (int)sdr["StudentID"], sdr["NationalCode"].ToString(),
            //            //                         sdr["Name"].ToString(), sdr["Family"].ToString(),
            //            //                         sdr["FatherName"].ToString(), (Int16)sdr["EntryYear"],
            //            //                         sdr.GetInt32(6), sdr["PhoneNumber"].ToString(),
            //            //                         sdr["Address"].ToString(), sdr["PostalCode"].ToString()));

            //            students.Add(new Student(sdr.GetInt32(0), sdr.GetString(1),
            //                                     sdr.GetString(2), sdr.GetString(3),
            //                                     sdr.GetString(4), sdr.GetInt16(5),
            //                                     sdr.GetInt32(6), sdr.GetString(7),
            //                                     sdr.GetString(8), sdr.GetString(9)));
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No rows found.");
            //    }

            //    // Displaying a message
            //    Console.WriteLine("Students selected Successfully");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("OOPs, something went wrong.\n" + e);
            //}
            //// Closing the connection  
            //finally
            //{
            //    connection.Close();
            //}

            //return students;
            #endregion
        }
    }
}
