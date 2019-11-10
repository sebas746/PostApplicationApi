using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.DataContext.PostApplication
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public DateTime PostPublicationDate { get; set; }
        public PostState PostState { get; set; }
        public User PostUser { get; set; }
    }
}
