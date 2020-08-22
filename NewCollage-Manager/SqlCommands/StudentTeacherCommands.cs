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
    /// A class for quering on StudentTeachers(دانشجو و استاد) table
    /// </summary>
    public class StudentTeacherCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public StudentTeacherCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// ساخت جدول ارتباط چند به چند استاد با دانشجو
        /// </summary>
        public void CreateStudentTeacherTable()
        {
            string queryString =
                    "create table StudentTeachers(" +
                        "StudentId int not null," +
                        "TeacherId int not null," +

                        "FOREIGN KEY (TeacherId) REFERENCES Teachers(HeadTeachId)," +
                        "FOREIGN KEY (StudentId) REFERENCES Students(StudentId)" +
                    ")";

            try
            {
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("StudentTeachers table created Successfully");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// اضافه کردن ردیف در جدول رابطه استاد با دانشجو
        /// </summary>
        /// <param name="st"></param>
        public void InsertStudentTeacher(StudentTeacher st)
        {
            string queryString =

                    "insert into StudentTeachers " +
                    "(" +
                            "StudentId," +
                            "TeacherId" +
                    ") " +
                    "values" +
                    "(" +
                            $"{st.StudentId}, " +
                            $"{st.TeacherId} " +
                    ")";

            try
            {
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into StudentTeachers table Successfully");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
