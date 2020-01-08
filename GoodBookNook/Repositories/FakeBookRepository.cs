using GoodBookNook.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoodBookNook.Repositories
{
    // This is class is just for testing.
    public class FakeBookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        public List<Book> Books { get { return books; } }

        public void AddBook(Book book)
        {
            book.BookID = books.Count;  // This simulates EF adding an ID based on the automatically created primary key.
            books.Add(book);
        }

        public void AddReview(Book book, Review review)
        {
            // There will only be one book with a matching ID, 
            // but I'm using books.First so I return a single Book object instead of a collection.
            Book theBook = books.First<Book>(b => b.BookID == book.BookID);
            theBook.Reviews.Add(review);
        }
        public Book GetBookByTitle(string title)
        {
            Book book = books.Find(b => b.Title == title);
            return book;
        }

    }
}