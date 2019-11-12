using Microsoft.EntityFrameworkCore;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostApplication.Data.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly PostApplicationContext context;
        public PostRepository(PostApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Blog> GetBlogPosts(int BlogId)
        {
            var result = context.Blogs.Include(p => p.Posts).Where(b => b.BlogId == BlogId);
            return result;
        }

        public Post GetPost(int PostId)
        {
            var result = context.Posts.Include(p => p.PostState).Where(p => p.PostId == PostId).FirstOrDefault();
            return result;
        }

        public IEnumerable<Post> GetPost()
        {
            var result = context.Posts.Include(p => p.PostState).Include(p => p.PostUser);
            return result;
        }

        public IEnumerable<Blog> GetBlogPosts()
        {
            var result = context.Blogs.Include(p => p.Posts).Take(10);
            return result;
        }

        public IEnumerable<Post> GetPendingForApprovalPosts(int BlogId)
        {
            var result = context.Posts.Include(p => p.PostState).Where(p => p.PostState.PostStateName == "Pending for Approval" && p.Blog.BlogId == BlogId);
            return result;
        }

        public Post UpdatePost(Post Post)
        {
            base.Update(Post);            
            return Post;
        }

        public PostState GetPostState(string PostStateName)
        {
            var result = context.PostStates.Where(ps => ps.PostStateName == PostStateName).FirstOrDefault();
            return result;
        }

        //public Post CreatePost(Post Post)
        //{
        //    base.Insert(Post);
        //    return Post;
        //}

        //public bool DeletePost(int PostId)
        //{
        //    base.Delete(PostId);
        //    return true;
        //}
    }
}
