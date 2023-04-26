
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models.Domain;

namespace UserManagement.Data
{
    public class UserManagementDbContext:DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext>options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
