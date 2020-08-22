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
    /// A class for quering on Corses table
    /// </summary>
    public class CourseCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public CourseCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساختن جدول دروس
        /// </summary>
        public void CreateCourseTable()
        {
            string queryString =
                    "create table Courses(" +
                        "CourseId int identity(101, 1) PRIMARY KEY," +
                        "Title nvarchar(50) not null, " +
                        "Credit tinyInt not null," +
                        "CreditType bit not null," + // True for takhasosi, False for omumi
                        "HeadTeachId int not null FOREIGN KEY (HeadTeachId) REFERENCES HeadTeachs(HeadTeachId)" +
                    ");";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Courses table created Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// افزودن یک درس جدید در دیتابیس
        /// </summary>
        /// <param name="c">درسی که در دیتابیس اضافه میشود</param>
        public void InsertCourse(Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =

                    "insert into Courses " +
                    "(" +
                            "Title," +
                            "Credit," +
                            "CreditType," +
                            "HeadTeachId" +
                    ") " +
                    "values" +
                    "(" +
                            $"N'{c.Title}', " +
                            $"{c.Credit}, " +
                            $"{type}," +
                            $"{c.HeadTeachId}" +
                    ")";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into Courses table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// حذف اطلاعات یک درس با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی درس مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        public void DeleteCourse(int id)
        {
            string queryString =
                     $"delete from Courses where CourseId = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Courses deleted Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// تغییر اطلاعات یک درس با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی درس مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="c">درس جدید که به جای درس قبلی قرار خواهد گرفت</param>
        public void UpdateCourse(int id, Course c)
        {
            int type = c.CreditType ? 1 : 0;
            string queryString =
                     $"update Courses set " +
                        $"Title = N'{c.Title}', " +
                        $"Credit = {c.Credit}, " +
                        $"CreditType = {type}," +
                        $"HeadTeachId = {c.HeadTeachId}" +
                     $"where CourseId = {id}";

            try
            {
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Courses update Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// نمایش اطلاعات یک درس با استفاده از آیدی درس
        /// </summary>
        /// <param name="id">آیدی درس مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از دروسی که آیدی مورد نظر را دارند</returns>
        public List<Course> SelectCourse(int id, SqlDataAdapter adapter)
        {
            string queryString =
                    $"select * from Courses where CourseId = {id}";

            List<Course> courses = new List<Course>();
            DataSet ds = new DataSet();

            try
            {
                adapter.SelectCommand = new SqlCommand(queryString, Connection);

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
            catch (Exception)
            {
                throw;
            }

            return courses;
        }
    }
}
