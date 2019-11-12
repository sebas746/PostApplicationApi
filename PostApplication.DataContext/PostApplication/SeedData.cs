using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostApplication.DataContext.PostApplication
{
    public class SeedData
    {
        public static void SeedDatabase(PostApplicationContext context)
        {
            if (context.Database.GetMigrations().Count() > 0
                      && context.Database.GetPendingMigrations().Count() == 0
                      && context.Roles.Count() == 0)
            {
                var r1 = new Role
                {
                    RoleDescription = "Role for Writers",
                    RoleName = "Writer"
                };

                var r2 = new Role
                {
                    RoleDescription = "Role for Editors",
                    RoleName = "Editor"
                };

                var u1 = new User
                {
                    Role = r1,
                    Username = "juan1",
                    UserEmail = "email@email.com",
                    UserFirstName = "Juan",
                    UserLastName = "Arango",
                    UserPassword = "12345"
                };

                var u2 = new User
                {
                    Role = r1,
                    Username = "felipe1",
                    UserEmail = "email@email.com",
                    UserFirstName = "Felipe",
                    UserLastName = "Caicedo",
                    UserPassword = "12345"
                };

                var u3 = new User
                {
                    Role = r2,
                    Username = "camila1",
                    UserEmail = "email@email.com",
                    UserFirstName = "Camila",
                    UserLastName = "Olarte",
                    UserPassword = "12345"
                };

                var u4 = new User
                {
                    Role = r2,
                    Username = "pablo1",
                    UserEmail = "email@email.com",
                    UserFirstName = "Pablo",
                    UserLastName = "Arango",
                    UserPassword = "12345"
                };

                var ps1 = new PostState
                {
                    PostStateName = "New",
                    PostStateDescription = "New Post"
                };
                var ps2 = new PostState
                {
                    PostStateName = "Pending for Approval",
                    PostStateDescription = "Pending publish approval"
                };

                var ps3 = new PostState
                {
                    PostStateName = "Approved",
                    PostStateDescription = "Post approved"
                };

                var ps4 = new PostState
                {
                    PostStateName = "Rejected",
                    PostStateDescription = "Post refused"
                };

                var p1 = new Post
                {
                    PostPublicationDate = DateTime.Now,
                    PostTitle = "Title Post 1",
                    PostState = ps2,
                    PostText = "New post created",
                    PostUser = u1
                };

                var p2 = new Post
                {
                    PostPublicationDate = DateTime.Now,
                    PostTitle = "Title Post 2",
                    PostState = ps3,
                    PostText = "Second post created",
                    PostUser = u1
                };

                var b1 = new Blog
                {
                    BlogCreationDate = DateTime.Now,
                    BlogDescription = "Blog for testing",
                    BlogTitle = "General Blog",
                    Posts = new List<Post>() { p1, p2 }
                };

                context.AddRange(ps1, ps4);
                context.AddRange(p1, p2);
                context.AddRange(b1);
                context.AddRange(u1, u2, u3, u4);
                context.SaveChanges();
            }
        }
    }
}
