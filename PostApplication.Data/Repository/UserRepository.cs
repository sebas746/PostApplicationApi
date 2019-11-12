using Microsoft.EntityFrameworkCore;
using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostApplication.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PostApplicationContext context;

        public UserRepository(PostApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public User CheckUser(UserDTO UserData)
        {
            var response = context.Users.Include(u => u.Role).Where(u => u.Username == UserData.Username && u.UserPassword == UserData.Password).FirstOrDefault();
            return response;
        }

        public User GetUSerByUsername(string Username)
        {
            var response = context.Users.Where(u => u.Username == Username).FirstOrDefault();
            return response;
        }
    }
}
