using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageManager {
    public class Program {
        static void Main(string[] args)
        {
            SqlConnection connection =
                    new SqlConnection("data source=.; database=Collage; integrated security=SSPI");

            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                HeadTeachCommands htCommands = new HeadTeachCommands(connection);
                //htCommands.CreateHeadTeachTable();
                //HeadTeach ht = new HeadTeach("0379999999", "Ali", "Kazemi",
                //                             "Davood", "09210275569", "Afsarieh",
                //                             "پشتیبان شبکه");
                //htCommands.InsertHeadTeach(ht);
                //HeadTeach ht2 = new HeadTeach("0370000000", "Hasan", "Kazemi",
                //                             "Davood", "09904693079", "Afsarieh",
                //                             " دانشجو");
                //htCommands.InsertHeadTeach(ht2);
                //htCommands.DeleteHeadTeach(2001);
                //HeadTeach htCopy = (HeadTeach)ht.Clone();
                //htCopy.NationalCode = "0372047041";
                //htCommands.UpdateHeadTeach(2001, htCopy);
                //foreach (var item in htCommands.SelectHeadTeach(2002, adapter))
                //{
                //    Console.WriteLine(item);
                //}
                //htCommands.DropHeadTeachTable();

                StudentCommands sCommands = new StudentCommands(connection);
                //sCommands.CreateStudentTable();
                //Student st = new Student("0370000000", "Ali", "Kazemi", "Davood",
                //                         1397, "09904693079", "Tehran", "0123456789",
                //                         "مهندسی کامپیوتر", "کارشناسی", 2001);
                //sCommands.InsertStudent(st);
                //sCommands.DeleteStudent(99001);
                //Student stCopy = (Student)st.Clone();
                //stCopy.Name = "Reza";
                //sCommands.UpdateStudent(99002, stCopy);
                //foreach (var item in sCommands.SelectStudent(99002, adapter))
                //{
                //    Console.WriteLine(item);
                //}

                TeacherCommands tCommands = new TeacherCommands(connection);
                //tCommands.CreateTeacherTable();
                //Teacher t = new Teacher("0370000000", "Ali", "Kazemi", "Davood",
                //                         "09904693079", "Tehran", "استاد دانشگاه خواجه نصیر");
                //tCommands.InsertTeacher(t);
                //tCommands.DeleteTeacher(1002);
                //Teacher tCopy = (Teacher)t.Clone();
                //tCopy.Name = "Hasan";
                //tCommands.UpdateTeacher(1003, tCopy);
                //foreach (var item in tCommands.SelectTeacher(1003, adapter))
                //{
                //    Console.WriteLine(item);
                //}

                CourseCommands cCommands = new CourseCommands(connection);
                //cCommands.CreateCourseTable();
                //Course c = new Course("مبانی برنامه نویسی", 3, true, 2001);
                //cCommands.InsertCourse(c);
                //Course c2 = new Course("برنامه سازي پيشرفته", 3, true, 2001);
                //cCommands.InsertCourse(c2);
                //cCommands.DeleteCourse(101);
                //Course cCopy = (Course)c.Clone();
                //cCopy.Title = "ساختمان داده ها";
                //cCopy.Credit = 2;
                //cCommands.UpdateCourse(102, cCopy);
                //foreach (var item in cCommands.SelectCourse(102, adapter))
                //{
                //    Console.WriteLine(item);
                //}

                ExistingCourseCommands ecCommands = new ExistingCourseCommands(connection);
                //ecCommands.CreateExistingCourseTable();
                //ecCommands.InsertExistingCourse(new ExistingCourse(1001, 103));
                //ecCommands.InsertExistingCourse(new ExistingCourse(1001, 104));

                PrerequisitesCourseCommands pcCommands = new PrerequisitesCourseCommands(connection);
                //pcCommands.CreatePrerequisitesCourseTable();
                //pcCommands.InsertPrerequisitesCourse(new PrerequisitesCourse(104, 103));

                StudentCourseCommands scCommands = new StudentCourseCommands(connection);
                //scCommands.CreateStudentCourseTable();
                //scCommands.InsertStudentCourse(new StudentCourse(, ));

                StudentTeacherCommands stCommands = new StudentTeacherCommands(connection);
                //stCommands.CreateStudentTeacherTable();
                //stCommands.InsertStudentTeacher(new StudentTeacher(, ));
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n\n" + e);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
