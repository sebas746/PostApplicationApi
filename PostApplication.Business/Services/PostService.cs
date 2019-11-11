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

        public IEnumerable<Blog> GetBlogPosts()
        {
            var response = uow.Post.GetBlogPosts();
            return response;
        }

        public IEnumerable<Post> GetPendingForApprovalPosts(int BlogId)
        {
            var response = uow.Post.GetPendingForApprovalPosts(BlogId);
            return response;
        }

        public Post ApproveOrRejectPost(int PostId, bool IsApproved)
        {
            var Post = uow.Post.GetPost(PostId);

            var postStateName = "Approved";

            if (!IsApproved)
            {
                postStateName = "Rejected";
            }

            var PostState = uow.Post.GetPostState(postStateName);

            Post.PostState = PostState;

            var response = uow.Post.UpdatePost(Post);
            uow.Complete();
            
            return response;
        }
    }
}
