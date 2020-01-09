
using GoodBookNook.Controllers;
using GoodBookNook.Models;
using System.Collections.Generic;
using Xunit;

namespace GoodBookNook.Tests
{
    public class AuthorTests
    {
        public AuthorTests()
        {
        }

        [Fact]
        // Test AuthorController getting a list of authors
        public void DoesGetAuthors()
        {
            // Arrange
            var repository = new FakeAuthorRepository();
            var controller = new AuthorController(repository);

            // Act
            var authors = (List<Author>)controller.Index().ViewData.Model;

            // Assert
            if (authors != null)
            {
                Assert.Equal(repository.GetAllAuthors()[0].Name,
                    authors[0].Name);
                Assert.Equal(repository.GetAllAuthors()[0].Birthday,
                    authors[0].Birthday);
                Assert.Equal(repository.GetAllAuthors()[1].Name,
                    authors[1].Name);
                Assert.Equal(repository.GetAllAuthors()[1].Birthday,
                    authors[1].Birthday);
            }
        }
    }

}
