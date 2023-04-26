using System;
using System.Data.SqlClient;

  

namespace Adonet_SQLServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection con = null;
            while (true)
            {
                Console.WriteLine("Enter Your Choice:");
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Select");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Search");
                int ch = Convert.ToInt32(Console.ReadLine());

                try
                {
                    // Creating Connection  
                    con = new SqlConnection("data source=INLEN8520051089\\SQLEXPRESS; database=Student; integrated security=SSPI");
                    // writing sql query  
                    con.Open();
                    
                        
                    SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50))", con);

                            //cm.ExecuteNonQuery();
                            //Console.WriteLine("Table Created Successfully....");
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Enter ID, name, Email of Employee:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            string name = Console.ReadLine();
                            string email = Console.ReadLine();
                            //DateTime join_date = new DateTime();
                           //string join_date = Console.ReadLine();
                            SqlCommand cm1 = new SqlCommand("insert into student (id, name, email) values ("+id+", '"+name+ "', '"+email+ "')", con);
                            int rf = cm1.ExecuteNonQuery();
                            Console.WriteLine("\nData inserted Successfully.....Rows affected:" + rf);
                            break;
                        case 2:
                    SqlCommand cm2 = new SqlCommand("select * from student", con);

                    Console.WriteLine("\nData Retrived From Table:");
                    SqlDataReader reader = cm2.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["id"] + ",  " + reader["name"] + ",  " + reader["email"] + ", ");
                    }
                    reader.Close();
                            break;
                        case 3:

                            Console.WriteLine("Enter ID of Emplyee you want to Update:");
                            int up = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Column of Emplyee you want to Update:");
                            string col = Console.ReadLine();
                            Console.WriteLine("Enter updated value of Emplyee:");
                            string row = Console.ReadLine();

                            SqlCommand cm5 = new SqlCommand("update student set "+col+"='"+row+"' where id='" + up + "'", con);
                            int rf1 = cm5.ExecuteNonQuery();
                            Console.WriteLine("\nData updated Successfully.....Rows affected:" + rf1);
                            break;
                        case 4:

                            Console.WriteLine("Enter ID of Emplyee you want to delete:");
                            int del = Convert.ToInt32(Console.ReadLine());
                           
                            SqlCommand cm3 = new SqlCommand("delete from student where id='" +del+"'", con);
                            int ra = cm3.ExecuteNonQuery();
                            Console.WriteLine("\nData delated Successfully.....Rows affected:" + ra);
                            break;
                        case 5:
                    Console.WriteLine("Enter name:");
                    string val = Console.ReadLine();
                    SqlCommand cm4 = new SqlCommand("select * from student where name='" + val + "'", con);
                    SqlDataReader reader1 = cm4.ExecuteReader();
                    while (reader1.Read())
                    {
                        Console.WriteLine(reader1["id"] + ",  " + reader1["name"] + ",  " + reader1["email"] + ", ");
                    }
                            break;
                        default:
                           
                            Console.WriteLine("\nSorry.....wrong choice...");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong." + e);
                }
                // Closing the connection  
                finally
                {
                    con.Close();
                }
            
            }
        }
    }
    
    
}
