using System;
using System.Collections.Generic;
using GoodBookNook.Models;
using GoodBookNook.Repositories;

namespace GoodBookNook.Tests
{
    public class FakeAuthorRepository : IAuthorRepository
    {
        public List<Author> GetAllAuthors()
        {
            var authors = new List<Author>();
            authors.Add(new Author() { Name = "Jame Austen", Birthday = new DateTime(1775, 12, 16) });
            authors.Add(new Author() { Name = "William Shakespere", Birthday = new DateTime(1564, 4, 1) });
            return authors;
        }

        public Author GetAuthorByName(string name)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public int Edit(Author author)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }

        public int Add(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
