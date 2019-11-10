using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Services;

namespace PostApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IPostService postService;

        public BlogController(IPostService postService)
        {
            this.postService = postService;
        }

        //// GET api/<controller>
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            var response = postService.GetBlogPosts(1);
            return response;
        }

        //// GET api/<controller>
        [HttpGet("{id}")]
        public IEnumerable<Blog> Get(int id)
        {
            var response = postService.GetBlogPosts(id);
            return response;
        }
    }
}