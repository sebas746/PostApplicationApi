using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Core.DTO
{
    public class PostDTO
    {
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostPublisherUsername { get; set; }        
    }
}
