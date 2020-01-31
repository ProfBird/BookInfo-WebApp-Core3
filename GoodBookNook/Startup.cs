using System.Runtime.InteropServices;
using GoodBookNook.Models;
using GoodBookNook.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace GoodBookNook
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
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.AddMvc();

            // Inject our repositories into our controllers
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // For SQL Server, localdb
                services.AddDbContext<AppDbContext>();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // For MariaDB
                services.AddDbContext<MySqlDbContext>();
            }
            else
            {
                // For Mac OS with SQLite
                services.AddDbContext<SqliteDbContext>();
            }

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (httpContext, next) =>
            {
                // Click-jacking mitigation
                // Tell the browser that the page can only be framed if the framing domain is this site's domain. 
                httpContext.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                // Prevent session IDs on cookies from being cached, but allow everything else to be cached.
                // httpContext.Response.Headers[HeaderNames.CacheControl]="no-cashe='set-cookie, set-cookie2'";
                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Add a few books and reviews as sample data.
            SeedData.Seed(context, app.ApplicationServices);

            AppDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
