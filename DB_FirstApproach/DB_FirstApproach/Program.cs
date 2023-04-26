using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_FirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EF_DemoDBEntities DBEntities = new EF_DemoDBEntities();
                while (true)
                {
                    Console.WriteLine("Enter Your Choice:");
                    Console.WriteLine("1.Insert\n2.Display\n3.Delete\n4.Update\n5.Search\n6.Exit");
                    int ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Enter Student Fistname:");
                            string fn = Console.ReadLine();
                            Console.WriteLine("Enter Student Lastname:");
                            string ln = Console.ReadLine();
                            Console.WriteLine("Enter Student standard id:");
                            int sid = Convert.ToInt32(Console.ReadLine());
                            var student = new Student
                            {
                                FirstName = fn,
                                LastName = ln,
                                StandardId = sid

                            };

                            DBEntities.Students.Add(student);
                            DBEntities.SaveChanges();
                            Console.WriteLine("Student added");

                            Console.WriteLine("Enter Teacher Fistname:");
                            string tfn = Console.ReadLine();
                            Console.WriteLine("Enter Teacher Lastname:");
                            string tln = Console.ReadLine();
                            Console.WriteLine("Enter Teacher standard id:");
                            int tid = Convert.ToInt32(Console.ReadLine());
                            var t = new Teacher
                            {

                                FirstName = tfn,
                                LastName = tln,
                                StandardId = tid

                            };
                            DBEntities.Teachers.Add(t);
                            DBEntities.SaveChanges();
                            Console.WriteLine("Teacher added");

                            break;
                        case 2:
                            List<Student> listStudents = DBEntities.Students.ToList();
                            Console.WriteLine();
                            foreach (Student stud in listStudents)
                            {
                                Console.WriteLine($" Name = {stud.FirstName} {stud.LastName}");
                            }

                            List<Teacher> listTeachers = DBEntities.Teachers.ToList();
                            Console.WriteLine();
                            foreach (Teacher teach in listTeachers)
                            {
                                Console.WriteLine($" Name = {teach.FirstName} {teach.LastName}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter student id you want to delete:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var student1 = DBEntities.Students.Find(id);
                            DBEntities.Students.Remove(student1);
                            DBEntities.SaveChanges();
                            Console.WriteLine("Student Removed");
                            break;
                        case 4:
                            Console.WriteLine("Enter student id you want to Update:");
                            int uid = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter student FirstName:");
                            string val1 = Console.ReadLine();
                            Console.WriteLine("Enter student LastName:");
                            string val2 = Console.ReadLine();

                            var student2 = DBEntities.Students.Find(uid);
                            student2.FirstName = val1;
                            student2.LastName = val2;
                            DBEntities.SaveChanges();
                            Console.WriteLine("Student Updated");

                            break;
                        case 5:
                            Console.WriteLine("Enter student id you want to Search:");
                            int seid = Convert.ToInt32(Console.ReadLine());
                            var st1 = (from std in DBEntities.Students
                                       where std.StudentId == seid
                                       select std).FirstOrDefault();
                            Console.WriteLine($"FirstName: {st1.FirstName}, LastName: {st1.LastName}");

                            break;
                        
                        default:
                            Console.WriteLine("Sorry..Wrong choice");

                            break;



                    }

                }
            }catch(Exception e)
            {
                Console.WriteLine("Something Went Wrong...!!!"+e);
            }
        }

    }
}
