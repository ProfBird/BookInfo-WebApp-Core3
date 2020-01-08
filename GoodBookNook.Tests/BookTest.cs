using System;
using System.Collections.Generic;
using GoodBookNook.Controllers;
using GoodBookNook.Models;
using GoodBookNook.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GoodBookNook.Tests
{
    public class BookTest
    {
        // Verify that the AddBook HttpPost method puts a new book in the book repository
        [Fact]
        public void AddBookTest()
        {
            // Arrange
            var repo = new FakeBookRepository();
            var bookController = new BookController(repo);

            // Act
            bookController.AddBook("A Tale of Two Cities",
                "Charles Dickens", "1/1/1859");
            // Assert
            Assert.Equal("A Tale of Two Cities",
                repo.Books[repo.Books.Count - 1].Title);
        }

        // Verify that the Index HttpGet method returns a sorted list of books.
        [Fact]
        public void IndexTest()
        {
            // Arrange
            var repo = new FakeBookRepository();
            AddTestBooks(repo);
            var bookController = new BookController(repo);

            // Act - get a list of books sorted by title in ascending order
            var result = (ViewResult)bookController.Index();
            var books = (List<Book>)result.Model;
            // Assert that book titles are in ascending order.
            // This implicitly checks that there are three books in the list as well.
            Assert.True(string.Compare(books[0].Title, books[1].Title) < 0 &&
                        string.Compare(books[1].Title, books[2].Title) < 0);
        }

        // Verify that the AddReview HttpPost method adds a review for a specific book.
        [Fact]
        public void AddReviewTest()
        {
            // Arrange
            var repo = new FakeBookRepository();
            AddTestBooks(repo);
            var bookController = new BookController(repo);

            // Act
            bookController.AddReview("Sense and Sensibility",
                                       "This book is a classic!", "A. Reader");
            // Assert
            Assert.Equal("This book is a classic!",
                repo.GetBookByTitle("Sense and Sensibility").Reviews[0].ReviewText);

        }

        // This method adds three books and authors, and one review to the repository.
        private void AddTestBooks(FakeBookRepository repo)
        {
            // Add the first book
            Book book = new Book()
            {
                Title = "The Fellowship of the Ring",
                PubDate = new DateTime(1937, 1, 1)
            };
            book.Authors.Add(new Author
            {
                Name = "J.R.R. Tolkein"
            }
            );
            repo.AddBook(book);

            // Add the second book
            book = new Book()
            {
                Title = "Sense and Sensibility",
                PubDate = new DateTime(1811, 1, 1)
            };
            book.Authors.Add(new Author
            {
                Name = "Jane Austen"
            }
            );
            repo.AddBook(book);

            // Add the third book and a review
            book = new Book()
            {
                Title = "Paradise Lost",
                PubDate = new DateTime(1667, 1, 1)
            };
            book.Authors.Add(new Author
            {
                Name = "John Milton"
            }
            );
            Review review = new Review() { ReviewText = "Awesome book!" };
            book.Reviews.Add(review);
            repo.AddBook(book);
        }
    }
}