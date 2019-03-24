
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Blog.Data.Context
{
    public class BlogContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            string connectionString = configuration["DATABASE_URL"];
            bool isUrl = Uri.TryCreate(connectionString, UriKind.Absolute, out Uri url);
            string host = url.Host;
            string port = url.Port.ToString();
            string dbName = url.LocalPath.Substring(1);
            string userId = url.UserInfo.Split(':')[0];
            string password = url.UserInfo.Split(':')[1];
            string cs = $"User ID={userId};Password={password};Server={host};Port={port};Database={dbName};Pooling=true;Trust Server Certificate=true;SslMode=Prefer";
            optionsBuilder.UseNpgsql(cs);
            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
