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
    }
}
