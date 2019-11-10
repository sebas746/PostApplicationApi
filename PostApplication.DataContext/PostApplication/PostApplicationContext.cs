using Microsoft.EntityFrameworkCore;

namespace PostApplication.DataContext.PostApplication
{
    public class PostApplicationContext : DbContext
    {
        public PostApplicationContext(DbContextOptions<PostApplicationContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostState> PostStates { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasMany<Post>(m => m.Posts);
        }
    }
}
