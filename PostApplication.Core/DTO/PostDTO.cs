using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Core.DTO
{
    public class post
    {
        public Post Post { get; set; }
        public Role CreaterRole { get; set; }
    }
}
