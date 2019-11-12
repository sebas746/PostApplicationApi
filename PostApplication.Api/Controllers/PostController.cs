using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Services;

namespace PostApplication.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [Route("CreatePost")]
        [HttpPost]
        public ActionResult<Post> CreatePost(Post post)
        {
            var response = postService.CreatePost(post);
            return Ok(response);
        }

        //// GET api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPost()
        
        {
            var response = postService.GetPosts();
            return Ok(response);
        }

        //// GET api/<controller>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Blog>> GetPost(int id)
        {
            var response = postService.GetBlogPosts(id);
            return Ok(response);
        }

        // GET api/<controller>
        [Route("GetPendingForApprovalPosts/")]
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPendingForApprovalPosts()
        {
            var response = postService.GetPendingForApprovalPosts(1);
            return Ok(response);
        }

        /// <summary>
        /// Approve or reject a post
        /// </summary>
        /// <param name="PostId"></param>
        /// <param name="IsApproved"></param>
        /// <returns></returns>
        [Route("ApproveOrRejectPost/")]
        [HttpGet]
        public ActionResult<Post> ApproveOrRejectPost(int PostId, bool IsApproved)
        {
            var response = postService.ApproveOrRejectPost(PostId, IsApproved);
            return Ok(response);
        }

        /// <summary>
        /// Delete a Post from database.
        /// </summary>
        /// <param name="PostId">Post Id to delete</param>
        [HttpDelete("{id}")]
        public void Delete(int PostId)
        {
            postService.DeletePost(PostId);
        }
    }
}