using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Interfaces.Services
{
    public interface IPostService
    {
        IEnumerable<Blog> GetBlogPosts(int BlogId);
    }
}
