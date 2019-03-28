using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.CQRS.BackOffice.Blogs.Queries;
using Blog.Data.Context;
using Blog.Data.Model.Identity;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.BackOffice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
            {
                
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
                o.Lockout.MaxFailedAccessAttempts = 5;

            }).AddEntityFrameworkStores<BlogDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(o =>
            {
                o.LoginPath = "/auth/login";
                o.AccessDeniedPath = "/auth/login";
                o.LogoutPath = "/Home/Index";
            });

            string connectionString = Configuration.GetConnectionString("DATABASE_URL");
            bool isUrl = Uri.TryCreate(connectionString, UriKind.Absolute, out Uri url);
            string host = url.Host;
            string port = url.Port.ToString();
            string dbName = url.LocalPath.Substring(1);
            string userId = url.UserInfo.Split(':')[0];
            string password = url.UserInfo.Split(':')[1];
            string cs = $"User ID={userId};Password={password};Server={host};Port={port};Database={dbName};Pooling=true;Trust Server Certificate=true;SslMode=Prefer";
            

            services.AddDbContext<BlogDbContext>(options => options.UseNpgsql(cs));
            services.AddMediatR(typeof(BlogsQuery).Assembly);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(); app.UseAuthentication();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
