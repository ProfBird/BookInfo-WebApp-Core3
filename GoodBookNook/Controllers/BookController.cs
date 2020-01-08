using System;
using System.Collections.Generic;
using GoodBookNook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using GoodBookNook.Repositories;

namespace GoodBookNook.Controllers
{
    public class BookController : Controller
    {
        IBookRepository repo;
        public BookController(IBookRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            List<Book> books = repo.Books;
            books.Sort((b1, b2) => string.Compare(b1.Title, b2.Title, StringComparison.Ordinal));
            return View(books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        public IActionResult Authors()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddBook(string title,
                                              string author, string pubDate)
        {
            Book book = new Book { Title = title };
            book.Authors.Add(new Author() { Name = author });
            book.PubDate = DateTime.Parse(pubDate);
            repo.AddBook(book);  // this is temporary, in the future the data will go in a database

            return RedirectToAction("Index");
        }

        public IActionResult AddReview(string title)
        {
            return View("AddReview", HttpUtility.HtmlDecode(title));
        }

        [HttpPost]
        public RedirectToActionResult AddReview(string title,
                                                string reviewText,
                                                string reviewer)
        {
            Book book = repo.GetBookByTitle(title);
            repo.AddReview(book,
                new Review()
                {
                    Reviewer = new User() { Name = reviewer },
                    ReviewText = reviewText
                });
            return RedirectToAction("Index");
        }
    }
}