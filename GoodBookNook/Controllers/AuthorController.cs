using System;
using GoodBookNook.Models;
using GoodBookNook.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoodBookNook.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorRepository authorRepo;

        public AuthorController(IAuthorRepository repo)
        {
            authorRepo = repo;
        }

        /* Action methods */

        public ViewResult Index()
        {
            var authors = authorRepo.GetAllAuthors();
            return View(authors);
        }

        [HttpPost]
        public RedirectToActionResult Add(string name, DateTime bDay, int bookId)
        {
            authorRepo.Add(new Author { Name = name, Birthday = bDay });
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View("AuthorEntry", authorRepo.GetAuthorById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(String name, DateTime bDay, int authorid, int bookid)
        {
            Author author = new Author
            {
                Name = name,
                Birthday = bDay,
                AuthorID = authorid
            };

            authorRepo.Edit(author);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            authorRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
