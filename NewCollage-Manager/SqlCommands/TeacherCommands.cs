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
    /// A class for quering on Teachers table
    /// </summary>
    public class TeacherCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public TeacherCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساختن جدول اساتید
        /// </summary>
        public void CreateTeacherTable()
        {
            string queryString =
                    "create table Teachers(" +
                        "TeacherId int identity(1001, 1) PRIMARY KEY," +
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
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Teachers table created Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// افزودن یک استاد جدید در دیتابیس
        /// </summary>
        /// <param name="st">استادی که در دیتابیس اضافه میشود</param>
        public void InsertTeacher(Teacher st)
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
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into Teachers table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// حذف اطلاعات یک استاد با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی استاد مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        public void DeleteTeacher(int id)
        {
            string queryString =
                    $"delete from Teachers where TeacherId = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Teachers deleted Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// تغییر اطلاعات یک استاد با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی استاد مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="t">استاد جدید که به جای استاد قبلی قرار خواهد گرفت</param>
        public void UpdateTeacher(int id, Teacher t)
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
                    $"where TeacherId = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Teachers update Successfully");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// نمایش اطلاعات یک استاد با استفاده از آیدی استاد
        /// </summary>
        /// <param name="id">آیدی استاد مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از اساتیدی که آیدی مورد نظر را دارند</returns>
        public List<Teacher> SelectTeacher(int id, SqlDataAdapter adapter)
        {
            string queryString =
                    $"select * from Teachers where TeacherId = {id}";

            List<Teacher> teachers = new List<Teacher>();
            DataSet ds = new DataSet();

            try
            {
                adapter.SelectCommand = new SqlCommand(queryString, Connection);

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
                    teacher.TeacherId = (int)row.ItemArray[0];
                    teachers.Add(teacher);
                }

                // Displaying a message
                Console.WriteLine("Teachers selected Successfully");
            }
            catch (Exception)
            {
                throw;
            }

            return teachers;
        }
    }
}
