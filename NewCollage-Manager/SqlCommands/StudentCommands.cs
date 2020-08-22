using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    /// <Author>Ali Kazemi</Author>
    /// <summary>
    /// A class for quering on Students table
    /// </summary>
    public class StudentCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public StudentCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساختن جدول دانشجویان
        /// </summary>
        public void CreateStudentTable()
        {
            string queryString =
                    "create table Students(" +
                        "StudentId int identity(99001, 1) PRIMARY KEY," +
                        "NationalCode varchar(10) check(LEN(NationalCode) = 10) not null unique," +
                        "Name nvarchar(50) not null, " +
                        "Family nvarchar(50) not null," +
                        "FatherName nvarchar(50) not null," +
                        "EntryYear smallInt not null check(EntryYear > 1394)," +
                        "PhoneNumber varchar(11) check(LEN(PhoneNumber) = 11 and PhoneNumber like '0%')," +
                        "Address nvarchar(150)," +
                        "PostalCode varchar(10) check(LEN(PostalCode) = 10)," +
                        "Field nvarchar(50) not null," +
                        "Grade nvarchar(50) not null," +
                        "HeadTeachId int not null," +

                        "CONSTRAINT FK_Student FOREIGN KEY (HeadTeachId) REFERENCES HeadTeachs(HeadTeachId)" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Students table created Successfully");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// افزودن یک دانشجو جدید در دیتابیس
        /// </summary>
        /// <param name="st">دانشجویی که در دیتابیس اضافه میشود</param>
        public void InsertStudent(Student st)
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
                            "HeadTeachId" +
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
                            $"{st.HeadTeachId}" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into Students table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// حذف اطلاعات یک دانشجو با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی دانشجوی مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        public void DeleteStudent(int id)
        {
            string queryString =
                    $"delete from Students where StudentId = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Students deleted Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// تغییر اطلاعات یک داشنجو با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی داشنجوی مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="st">داشنجوی جدید که به جای داشنجو قبلی قرار خواهد گرفت</param>
        public void UpdateStudent(int id, Student st)
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
                        $"HeadTeachId = {st.HeadTeachId}" +
                    $" where StudentId = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Students updated Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// نمایش اطلاعات یک دانشجو با استفاده از آیدی درس
        /// </summary>
        /// <param name="id">آیدی دانشجوی مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از دانشجویانی که آیدی مورد نظر را دارند</returns>
        public List<Student> SelectStudent(int id, SqlDataAdapter adapter)
        {
            string queryString =
                    $"select * from Students where StudentId = {id}";

            List<Student> students = new List<Student>();
            DataSet ds = new DataSet();

            try
            {
                adapter.SelectCommand = new SqlCommand(queryString, Connection);

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
            catch (Exception)
            {
                throw; 
            }

            return students;

            #region DataReader
            //string queryString =
            //        $"select * from Students where StudentId = {id}";

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
            //            //                         (int)sdr["StudentId"], sdr["NationalCode"].ToString(),
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
