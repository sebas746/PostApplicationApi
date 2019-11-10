using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Interfaces.Data
{
    public interface IPostRepository
    {
        IEnumerable<Blog> GetBlogPosts(int BlogId);
    }
}
