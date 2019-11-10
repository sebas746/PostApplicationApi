using Microsoft.EntityFrameworkCore;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostApplication.Data.Repository
{
    public class PostRepository :IPostRepository
    {
        private readonly PostApplicationContext context;
        public PostRepository(PostApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Blog> GetBlogPosts(int BlogId)
        {
            var result = context.Blogs.Include(p => p.Posts).Where(b => b.BlogId == BlogId);
            return result;
        }
    }
}
