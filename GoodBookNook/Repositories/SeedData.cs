using GoodBookNook.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GoodBookNook.Repositories
{
    public class SeedData
    {
        const string MEMBER_ROLE = "Member";
            
        public static async void Seed(AppDbContext context, IServiceProvider serviceProvider)
        {
            if (!context.Books.Any())
            {
                Author author = new Author { Name = "Samuel Shellabarger" };
                context.Authors.Add(author);

                await CreateRole(serviceProvider);
                AppUser user =  await AddUser(serviceProvider, "Walter Cronkite");

                Review review = new Review
                {
                    ReviewText = "Great book, a must read!",
                    Reviewer = user
                };
                context.Reviews.Add(review);

                Book book = new Book
                {
                    Title = "Prince of Foxes",
                    PubDate = DateTime.Parse("1/1/1947")
                };
                book.Authors.Add(author);
                book.Reviews.Add(review);
                context.Books.Add(book);

                context.SaveChanges(); // save all the data
            }
        }
        
        
        private static async Task CreateRole(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            if (await roleManager.FindByNameAsync(MEMBER_ROLE) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(MEMBER_ROLE));
            }
        }

        
        private static  async Task<AppUser> AddUser(IServiceProvider serviceProvider, string name)
        {
            AppUser user = null;
            
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string userName = name.Replace(" ", "");
            if (await userManager.FindByNameAsync(name) == null)
            {
                user = new AppUser
                {
                    UserName = userName,
                    Name = name,
                    Email = userName + "@example.com"
                };
                
                IdentityResult result = await userManager
                    .CreateAsync(user, "Password-1234");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, MEMBER_ROLE);
                }
            }
            return user;
        }
    }
}
