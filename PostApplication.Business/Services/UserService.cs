using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using PostApplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User CheckUser(UserDTO UserData)
        {
            var response = this.userRepository.CheckUser(UserData);
            return response;
        }
    }
}
