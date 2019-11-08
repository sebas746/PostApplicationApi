using Microsoft.EntityFrameworkCore;

namespace PostApplication.Data.Models
{
    public class DataContext : DbContext    
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostState> PostStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
