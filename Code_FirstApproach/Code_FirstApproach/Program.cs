using System;
using System.Collections.Generic;


namespace Code_FirstApproach
{
   
    class Program
    {
        static void Main(string[] args)
        {
            CodeFirst_DBContext context = new CodeFirst_DBContext();

            var Std = new Standard()
            {
                StandardId = 1,
                StandardName = "STD3",
                Description = "Average"

            };
            context.Standards.Add(Std);
            context.SaveChanges();
            Console.WriteLine("Standard Added");
            Console.ReadKey();

            var st = new Student() {
                FirstName = "John",
                LastName = "Conner",
                DateOfBirth = null,
                Height = 5,
                Weight = 24.6f,
                Standard=Std
                };
                context.Students.Add(st);
                context.SaveChanges();
                Console.WriteLine("Student Added");
                Console.ReadKey();
            
        }
    }
}
