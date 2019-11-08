using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public Role Role { get; set; }
    }
}
