using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Services;

namespace PostApplication.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("CheckUser/")]
        [HttpPost]
        public User CheckUser(UserDTO userData)
        {
            var response = userService.CheckUser(userData);
            return response;
        }
    }
}