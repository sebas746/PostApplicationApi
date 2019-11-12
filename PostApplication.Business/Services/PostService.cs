using PostApplication.Core.DTO;
using PostApplication.Core.Enums;
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
        private readonly IUserRepository userRepository;

        public PostService(IUnitOfWork uow, IPostRepository postRepository, IUserRepository userRepository)
        {
            this.uow = uow;
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<Blog> GetBlogPosts(int BlogId)
        {
            var response = uow.Post.GetBlogPosts(BlogId);
            return response;
        }

        public IEnumerable<Post> GetPosts()
        {
            var response = postRepository.GetPost();
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

        public Post CreatePost(PostDTO postDTO)
        {
            var postState = postRepository.GetPostStateById((int)Enums.PostStates.PendingForApproval);
            var blog = postRepository.GetBlog();
            var user = userRepository.GetUSerByUsername(postDTO.PostPublisherUsername);           

            var post = new Post()
            {
                Blog = blog,
                PostState = postState,
                PostId = 0,
                PostPublicationDate = DateTime.Now,
                PostText = postDTO.PostContent,
                PostTitle = postDTO.PostTitle,
                PostUser = user
            };

            postRepository.Insert(post);
            postRepository.Save();
            return post;
        }

        public Post DeletePost(int PostId)
        {
            var post = postRepository.GetByID(PostId);
            postRepository.Delete(PostId);
            postRepository.Save();
            return post;
        }

        public Post UpdatePost(Post post)
        {
            var postComplete = postRepository.GetPost(post.PostId);
            postComplete.PostText = post.PostText;
            postComplete.PostTitle = post.PostTitle;
            postRepository.Update(postComplete);
            postRepository.Save();
            return postComplete;
        }
    }
}
