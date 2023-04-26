using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_FirstApproach
{
    public class Student
    {
       
            public int StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }
            public virtual Standard Standard { get; set; }
        
    }
}
