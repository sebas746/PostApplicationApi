﻿using PostApplication.Core.DTO;
using PostApplication.DataContext.PostApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApplication.Interfaces.Services
{
    public interface IPostService
    {
        IEnumerable<Blog> GetBlogPosts(int BlogId);
        IEnumerable<Post> GetPendingForApprovalPosts(int BlogId);
        IEnumerable<Blog> GetBlogPosts();
        Post ApproveOrRejectPost(int PostId, bool IsApproved);
        Post DeletePost(int PostId);
        Post CreatePost(PostDTO postDTO);
        IEnumerable<Post> GetPosts();
        Post UpdatePost(Post post);
    }
}
