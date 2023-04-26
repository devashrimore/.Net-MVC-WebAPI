
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models.Domain;

namespace UserManagement.Repository
{
    public interface IUserDetails
    {
        IEnumerable<User> GetAllUserDetails();
        Task<User> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User> PutUser(int id, User user);
        Task<User> DeleteUser(int id);
    }
}
