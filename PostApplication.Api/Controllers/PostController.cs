﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.DataContext.PostApplication;
using PostApplication.Interfaces.Services;

namespace PostApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        //// GET api/<controller>
        [HttpGet]
        public IEnumerable<Blog> GetPost()
        {
            var response = postService.GetBlogPosts(1);
            return response;
        }

        //// GET api/<controller>
        [HttpGet("{id}")]
        public IEnumerable<Blog> GetPost(int id)
        {
            var response = postService.GetBlogPosts(id);
            return response;
        }
    }
}