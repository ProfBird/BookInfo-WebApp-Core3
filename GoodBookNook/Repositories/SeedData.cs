using GoodBookNook.Models;
using System;
using System.Linq;

namespace GoodBookNook.Repositories
{
    public class SeedData
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Books.Any())
            {
                Author author = new Author { Name = "Samuel Shellabarger" };
                context.Authors.Add(author);

                AppUser user = new AppUser { UserName = "WalterCronkite" };
                context.Users.Add(user);

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
    }
}
