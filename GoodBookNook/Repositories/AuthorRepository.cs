using System;
using System.Collections.Generic;
using System.Linq;
using GoodBookNook.Models;

namespace GoodBookNook.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext context;

        public AuthorRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = context.Authors.ToList<Author>();
            return authors;
        }

        public Author GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorById(int id)
        {
            return context.Authors.First(a => a.AuthorID == id);
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }

        public int Add(Author author)
        {
            context.Authors.Add(author);
            return context.SaveChanges();
        }

        public int Edit(Author author)
        {
            var authorFromDb = GetAuthorById(author.AuthorID);
            authorFromDb.Birthday = author.Birthday;
            authorFromDb.Name = author.Name;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var authorFromDb = context.Authors.First(a => a.AuthorID == id);
            context.Remove(authorFromDb);
            return context.SaveChanges();
        }
    }
}
