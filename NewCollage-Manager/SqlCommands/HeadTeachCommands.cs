using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCollage_Manager {
    public class HeadTeachCommands {

        private static SqlConnection connection =
            new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

        public static void DropHeadTeachTable()
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
        }
    }
}
