using PostApplication.Core.DTO;
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
        private readonly IPostRepository postRepository;

        public PostService(IUnitOfWork uow, IPostRepository postRepository)
        {
            this.uow = uow;
            this.postRepository = postRepository;
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

            postRepository.Update(Post);
            postRepository.Save();

            return Post;
        }

        public Post CreatePost(PostDTO PostDTO)
        {
            var post = PostDTO.Post;
            var postState = postRepository.GetPostState("Pending publish approval");
            post.PostState = postState;
            postRepository.Insert(post);
            postRepository.Save();
            //return Post;
            return null;
        }

        public void DeletePost(int PostId)
        {
            postRepository.Delete(PostId);
        }
    }
}
