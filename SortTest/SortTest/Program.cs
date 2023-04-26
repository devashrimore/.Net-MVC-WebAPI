using System;

namespace SortTest
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] name=new char[50];
            int i,j;

            char ch;
           Console.WriteLine("Enter the length of string:");
           int l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name:");
             for(i=0;i<l;i++)
             {
                 name[i] = Convert.ToChar(Console.Read());
             }
            
          
            for(i=0;i<l;i++)
            {
                for(j=0;j<l-i;j++)
                {
                    if(name[j]>name[j+1])
                    {
                        ch = name[j];
                        name[j] = name[j + 1];
                        name[j + 1] = ch;                    }
                }
            }

            Console.WriteLine(name);
             
           
            for (i = 0; i < l; i++)
            {
                for (j = 0; j < l - i; j++)
                {
                    if (name[j] < name[j + 1])
                    {
                        ch = name[j];
                        name[j] = name[j + 1];
                        name[j + 1] = ch;
                    }
                }
            }

            Console.WriteLine(name);
        }
    }
}
