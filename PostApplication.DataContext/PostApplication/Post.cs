using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PostApplication.DataContext.PostApplication
{
    public class Post
    {   
        public int PostId { get; set; }

        [StringLength(150)]
        public string PostTitle { get; set; }

        [StringLength(2000)]
        public string PostText { get; set; }
        public DateTime PostPublicationDate { get; set; }
        public PostState PostState { get; set; }
        public User PostUser { get; set; }
        public Blog Blog { get; set; }
    }
}
