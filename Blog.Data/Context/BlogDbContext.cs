using Blog.Data.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Context
{
    public class BlogDbContext :IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
  
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BlogDbContext()
        {
        }

        #region Dbset

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
