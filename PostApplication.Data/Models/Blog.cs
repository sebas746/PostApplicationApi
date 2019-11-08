using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Data.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public DateTime BlogCreationDate { get; set; }
        public List<Post> Posts { get; set; }
}
}
