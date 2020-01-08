using GoodBookNook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GoodBookNook.Repositories
{
    public  class BookRepository : IBookRepository
    {
        private AppDbContext context;
        // Get all books + associated data by using the EF Include method.
        public List<Book> Books { get { return context.Books.Include(book => book.Authors)
            .Include(book => book.Reviews).ThenInclude(review => review.Reviewer).ToList(); } }
        // We needed to use the EF ThenInclude method to get Reviewer. 
        // We had to use the overload of Include that uses lambda expressions
        // rather than the one that uses strings in order to use ThenInclude.

        public BookRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public  void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void AddReview(Book book, Review review)
        {
            book.Reviews.Add(review);
            context.Books.Update(book);
            context.SaveChanges();
        }

        public  Book GetBookByTitle(string title)
        {
            Book book;
            book = context.Books.First(b => b.Title == title);
            return book;
        }

    }
}
