using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PostApplication.Data.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
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

                context.AddRange(u1, u2, u3, u4);
                context.SaveChanges();
            }
            if (context.Database.GetMigrations().Count() > 0
                     && context.Database.GetPendingMigrations().Count() == 0
                     && context.PostStates.Count() == 0)
            {
                var ps1 = new PostState
                {
                    PostStateName = "New",
                    PostStateDescription = "New Post"
                };
                var ps2 = new PostState
                {
                    PostStateName = "Pending for Approval",
                    PostStateDescription = "Post pending for approval"
                };

                context.AddRange(ps1, ps2);
                context.SaveChanges();
            }
        }
    }
}
