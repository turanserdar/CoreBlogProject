using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Data.Entities;
using Blog.Services.Concrete;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog.Admin
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogDbContext>(option =>
            {
                option.UseSqlServer("Server=.;Database=BlogDev;User Id=sa;Password=123;");
            });

            services.AddScoped<IRepository<Category>, EFRepository<Category>>(); // DI
            services.AddScoped<IRepository<User>, EFRepository<User>>();
            services.AddScoped<IRepository<Tag>, EFRepository<Tag>>();
            services.AddScoped<IRepository<Comment>, EFRepository<Comment>>();  
            services.AddScoped<IPostRepository, PostRepository>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                  {
                      option.LoginPath = "/auth/login";
                      option.ExpireTimeSpan = TimeSpan.FromHours(1);
                  });


            services.AddControllersWithViews(); // MVC

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller}/{action}/{id?}", // www.goog.com/home/index/2
                     defaults: new { controller = "Home", action = "Index" }
                    );
            });

            app.UseStaticFiles();

        }
    }
}
