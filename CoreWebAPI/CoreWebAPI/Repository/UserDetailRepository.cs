
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Models.Domain;

namespace UserManagement.Repository
{
    public class UserDetailRepository : IUserDetails
    {
        private UserManagementDbContext _db;
        public UserDetailRepository(UserManagementDbContext userDb)
        {
            _db = userDb;
        }
        #region getalluserdetails
         public IEnumerable<User> GetAllUserDetails()
        {
            try
            {
                return _db.Users.ToList();
               
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
        public async Task<User> GetUser(int id)
        {
           

            return await _db.Users.FirstOrDefaultAsync(x => x.UserID == id);
        }
      

        public async Task<User> AddUser(User user)
        {
           // user.UserID = new int();
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
            
        }
        public async Task<User> DeleteUser(int id)
        {
           var data= await _db.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if(data==null)
            {
                return null;
            }
            //delete user
           _db.Users.Remove(data);
            await _db.SaveChangesAsync();
            return data;
        }

        public async Task<User> PutUser(int id, User user)
        {
            var existinguser=await _db.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if(existinguser==null)
            {
                return null;
            }
           
            existinguser.FirstName = user.FirstName;
            existinguser.LastName = user.LastName;
            existinguser.Email = user.Email;
            await _db.SaveChangesAsync();
            return existinguser;
        }
    }
}
