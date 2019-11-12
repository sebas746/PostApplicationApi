using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Interfaces.Services
{
    public interface IUserService
    {
        User CheckUser(UserDTO UserData);
    }
}
