//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_FirstApproach
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> StandardId { get; set; }
    
        public virtual Standard Standard { get; set; }
    }
}
