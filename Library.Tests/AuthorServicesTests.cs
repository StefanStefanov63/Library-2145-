using NUnit.Framework;
using Library.Services.Classes;
using Library.Services.Interfaces;
using Library.Services.ViewModelsClasses;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Library.Data;

namespace Library.Tests
{
    [TestFixture]
    public class AuthorServicesTests
    {
        private LibraryContext _dbContext;
        private IAuthorServices _authorServices;
        private IBookServices _bookServices;
        private ILibraryCardServices _libraryCardServices;
        private ILogServices _logServices;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new LibraryContext(options);
            SeedTestData();

            _authorServices = new AuthorServices(_dbContext);
            _bookServices = new BookServices(_dbContext);
            _libraryCardServices = new LibraryCardServices(_dbContext);
            _logServices = new LogServices(_dbContext);
        }

        private void SeedTestData()
        {
            _dbContext.Authors.AddRange(
                new Models.Author { Name = "Author1" },
                new Models.Author { Name = "Author2" }
            );

            _dbContext.SaveChanges();
        }

        [Test]
        public void RegisterNewAuthor_WhenNewAuthor_ShouldAddToDatabase()
        {
            string authorName = "John Doe";

            _authorServices.RegisterNewAuthor(authorName);
            var authors = _authorServices.GetAllAuthors();

            Assert.IsTrue(authors.Any(a => a.Name == authorName));
        }

        [Test]
        public void RegisterNewAuthor_WhenExistingAuthor_ShouldNotAddToDatabase()
        {
            _authorServices.RegisterNewAuthor("Author1");
            var authors = _authorServices.GetAllAuthors();
            Assert.AreEqual(2, authors.Count);
        }

        [Test]
        public void DeleteAuthorByName_WhenExistingAuthor_ShouldRemoveFromDatabase()
        {
            string authorName = "Author to Delete";
            _authorServices.RegisterNewAuthor(authorName);

            _authorServices.DeleteAuthorByName(authorName);
            var authors = _authorServices.GetAllAuthors();

            Assert.IsFalse(authors.Any(a => a.Name == authorName));
        }

        [Test]
        public void DeleteAuthorByName_WhenNonExistingAuthor_ShouldNotRemoveFromDatabase()
        {
            string nonExistingAuthorName = "Non Existing Author";

            _authorServices.DeleteAuthorByName(nonExistingAuthorName);
            var authors = _authorServices.GetAllAuthors();

            Assert.AreEqual(0, authors.Count(a => a.Name == nonExistingAuthorName));

        }


        [Test]
        public void UpdateAuthorName_WhenNonExistingAuthor_ShouldNotChangeName()
        {
            const string nonExistingAuthor = "NonExistingAuthor";
            const string newName = "UpdatedAuthor1";

            _authorServices.UpdateAuthorName(nonExistingAuthor, newName);


            var authors = _authorServices.GetAllAuthors();
            var updatedAuthor = authors.FirstOrDefault(a => a.Name == newName);
            Assert.IsNull(updatedAuthor);
        }

        [Test]
        public void GetAllAuthors_ShouldReturnAllAuthors_WhenAuthorsExist()
        {
            var authors = _authorServices.GetAllAuthors();


            Assert.AreEqual(2, authors.Count); //stefcho pomosht tva ne trqbva da e nula a samo kato e nula bachka ;-;-;-;-; NVM OPRAVIH GO LETS GOOO(ne sum si seednal dannite az sum bavnqr)
        }



    }

    public class AuthorServicesMock : IAuthorServices
    {
        private List<AuthorViewModel> _authors;

        public AuthorServicesMock()
        {
            _authors = new List<AuthorViewModel>();
        }

        public void RegisterNewAuthor(string aName)
        {
            _authors.Add(new AuthorViewModel { Name = aName });
        }

        public void DeleteAuthorByName(string aName)
        {
            var author = _authors.FirstOrDefault(a => a.Name == aName);
            if (author != null)
                _authors.Remove(author);
        }

        public void UpdateAuthorName(string aOldName, string aNewName)
        {
            var author = _authors.FirstOrDefault(a => a.Name == aOldName);
            if (author != null)
                author.Name = aNewName;
        }

        public ICollection<AuthorViewModel> GetAllAuthors()
        {
            return _authors;
        }

        public AuthorViewModel GetAuthorByName(string aName)
        {
            return _authors.FirstOrDefault(a => a.Name == aName);
        }

    }
}
