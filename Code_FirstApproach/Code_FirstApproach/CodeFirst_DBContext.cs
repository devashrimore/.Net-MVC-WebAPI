using System;
using System.Data.Entity;


namespace Code_FirstApproach
{

    class CodeFirst_DBContext: DbContext
    {
        
          
            public DbSet<Student> Students { get; set; }
            public DbSet<Standard> Standards { get; set; }
        
    }
}
