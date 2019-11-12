using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Interfaces.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User CheckUser(UserDTO UserData);
        User GetUSerByUsername(string Username);
    }
}
