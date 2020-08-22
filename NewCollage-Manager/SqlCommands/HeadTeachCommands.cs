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
    /// A class for quering on HeadTeachs table
    /// </summary>
    public class HeadTeachCommands {

        /// <summary>
        /// یک peroperty برای تنظیم اتصال به دیتابیس
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">اتصال به دیتابیس مورد نظر</param>
        public HeadTeachCommands(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// حذف جدول مسولین آموزش
        /// </summary>
        public void DropHeadTeachTable()
        {
            string queryString =
                    "drop table HeadTeachs";

            try
            {
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs table deleted Successfully");
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
        /// ساختن جدول مسولین آموزش
        /// </summary>
        public void CreateHeadTeachTable()
        {
            string queryString =
                    "create table HeadTeachs(" +
                        "HeadTeachId int identity(2001, 1)  PRIMARY KEY," +
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
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs table created Successfully");
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
        /// افزودن یک مسول آموزش جدید در دیتابیس
        /// </summary>
        /// <param name="ht">مسول آموزشی که در دیتابیس اضافه میشود</param>
        public void InsertHeadTeach(HeadTeach ht)
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
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Insert into HeadTeachs table Successfully");
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
        /// حذف اطلاعات یک مسول آموزش با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی مسول آموزش مورد نظر برای حذف اطلاعات آن از دیتابیس</param>
        public void DeleteHeadTeach(int id)
        {
            string queryString =
                     $"delete from HeadTeachs where HeadTeachId = {id}";
            try
            {
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs deleted Successfully");
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
        /// تغییر اطلاعات یک مسول آموزش با استفاده از آیدی
        /// </summary>
        /// <param name="id">آیدی مسول آموزش مورد نظر برای تغییر اطلاعات آن از دیتابیس</param>
        /// <param name="ht">مسول آموزش جدید که به جای درس قبلی قرار خواهد گرفت</param>
        public void UpdateHeadTeach(int id, HeadTeach ht)
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
                     $"where HeadTeachId = {id}";
            try
            {
                Connection.Open();
                SqlCommand cm = new SqlCommand(queryString, Connection);

                // Executing the SQL query  
                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("HeadTeachs update Successfully");
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
        /// نمایش اطلاعات یک مسول آموزش با استفاده از آیدی درس
        /// </summary>
        /// <param name="id">آیدی مسول آموزش مورد نظر برای نمایش اطلاعات آن از دیتابیس</param>
        /// <returns>یک لیست از مسول آموزش هایی که آیدی مورد نظر را دارند</returns>
        public List<HeadTeach> SelectHeadTeach(int id, SqlDataAdapter adapter)
        {
            string queryString =
                    $"select * from HeadTeachs where HeadTeachId = {id}";

            List<HeadTeach> headTeachs = new List<HeadTeach>();
            DataSet ds = new DataSet();

            try
            {
                Connection.Open();
                adapter.SelectCommand = new SqlCommand(queryString, Connection);

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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }

            return headTeachs;
        }
    }
}
