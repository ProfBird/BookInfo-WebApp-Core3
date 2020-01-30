using System;
using System.Collections.Generic;
using GoodBookNook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using GoodBookNook.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GoodBookNook.Controllers
{
    public class BookController : Controller
    {
        IBookRepository repo;
        UserManager<AppUser> userManager;

        public BookController(IBookRepository r, UserManager<AppUser> usrMgr)
        {
            repo = r;
            userManager = usrMgr;
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

        [HttpPost]
        public RedirectToActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.AddBook(book);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult AddReview(string title)
        {
            return View("AddReview", HttpUtility.HtmlDecode(title));
        }

        [HttpPost]
        public async Task<RedirectToActionResult> AddReview(string title,
                                                string reviewText,
                                                string reviewer)
        {
            Book book = repo.GetBookByTitle(title);
            repo.AddReview(book,
                new Review()
                {
                    // Reviewer = new AppUser() { Name = reviewer },
                   // Reviewer  =await userManager.FindByNameAsync(reviewer)
                   Reviewer = await userManager.GetUserAsync(HttpContext.User),
                    ReviewText = reviewText
                });
            return RedirectToAction("Index");
        }
    }
}