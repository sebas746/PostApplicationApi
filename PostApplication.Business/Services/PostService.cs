using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using PostApplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostApplication.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork uow;

        public PostService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Blog> GetBlogPosts(int BlogId)
        {
            var response = uow.Post.GetBlogPosts(BlogId);
            return response;
        }
    }
}
