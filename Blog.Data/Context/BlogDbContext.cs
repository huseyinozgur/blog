using Blog.Data.Model.Entity;
using Blog.Data.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Context
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BlogDbContext()
        {
        }

        #region Dbset
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostDetail> PostDetails { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ForNpgsqlUseIdentityColumns();
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
