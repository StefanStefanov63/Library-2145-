using Library.Data;
using Library.Services.Classes;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    [TestFixture]
    public class BookServicesTests
    {
        private LibraryContext _dbContext;
        private IBookServices _bookServices;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new LibraryContext(options);
            SeedTestData();

            _bookServices = new BookServices(_dbContext);
        }

        private void SeedTestData()
        {
            _dbContext.Authors.AddRange(
                new Models.Author { Name = "Author1" },
                new Models.Author { Name = "Author2" }
            );

            _dbContext.SaveChanges();

            _dbContext.Books.AddRange(
                new Models.Book { Title = "Book1", AuthorId = 1, Description = "Description1", Quantity = 3 },
                new Models.Book { Title = "Book2", AuthorId = 2, Description = "Description2", Quantity = 5 }
            );

            _dbContext.SaveChanges();
        }

        [Test]
        public void RegisterNewBook_WithValidData_ShouldAddToDatabase()
        {
            string bookTitle = "New Book";
            string authorName = "Author1";
            string description = "Description";
            int quantity = 2;

            _bookServices.RegisterNewBook(bookTitle, authorName, description, quantity);

            var books = _dbContext.Books.ToList();

            Assert.IsTrue(books.Any(b => b.Title == bookTitle));
            Assert.AreEqual(3, books.Count);
        }

        [Test]
        public void RegisterNewBook_WithExistingTitle_ShouldNotAddToDatabase()
        {
            string existingBookTitle = "Book1";
            string authorName = "Author1";
            string description = "Description";
            int quantity = 2;

            _bookServices.RegisterNewBook(existingBookTitle, authorName, description, quantity);

            var books = _dbContext.Books.ToList();

            Assert.AreEqual(2, books.Count);
        }

        [Test]
        public void RegisterNewBook_WithNegativeQuantity_ShouldNotAddToDatabase()
        {

            const string title = "New Book";
            const string author = "Author1";
            const string description = "Description";
            const int negativeQuantity = -2;

            _bookServices.RegisterNewBook(title, author, description, negativeQuantity);


            var books = _dbContext.Books.ToList();
            Assert.AreEqual(2, books.Count);
        }
        [Test]
        public void DeleteBookByTitle_WhenExistingBook_ShouldRemoveFromDatabase()
        {
            string existingBookTitle = "Book1";

            _bookServices.DeleteBookByTitle(existingBookTitle);

            var books = _dbContext.Books.ToList();

            Assert.IsFalse(books.Any(b => b.Title == existingBookTitle));
            Assert.AreEqual(1, books.Count);
        }

        [Test]
        public void DeleteBookByTitle_WhenNonExistingBook_ShouldNotRemoveFromDatabase()
        {
            string nonExistingBookTitle = "Non Existing Book";

            _bookServices.DeleteBookByTitle(nonExistingBookTitle);

            var books = _dbContext.Books.ToList();

            Assert.AreEqual(2, books.Count);
        }

        [Test]
        public void UpdateBookTitle_WhenExistingBook_ShouldUpdateTitle()
        {
            string existingBookTitle = "Book1";
            string newTitle = "New Title";

            _bookServices.UpdateBookTitle(existingBookTitle, newTitle);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == newTitle);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(newTitle, updatedBook.Title);
        }

        [Test]
        public void UpdateBookTitle_WhenNonExistingBook_ShouldNotUpdateTitle()
        {
            string nonExistingBookTitle = "Non Existing Book";
            string newTitle = "New Title";

            _bookServices.UpdateBookTitle(nonExistingBookTitle, newTitle);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == newTitle);

            Assert.IsNull(updatedBook);
        }
        [Test]
        public void UpdateBookAuthor_WhenExistingBook_ShouldUpdateAuthor()
        {
            string existingBookTitle = "Book1";
            string newAuthor = "New Author";

            _bookServices.UpdateBookAuthor(existingBookTitle, newAuthor);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == existingBookTitle);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(newAuthor, updatedBook.Author);
        }

        [Test]
        public void UpdateBookAuthor_WhenNonExistingBook_ShouldNotUpdateAuthor()
        {
            string nonExistingBookTitle = "Non Existing Book";
            string newAuthor = "New Author";

            _bookServices.UpdateBookAuthor(nonExistingBookTitle, newAuthor);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == nonExistingBookTitle);

            Assert.IsNull(updatedBook);
        }
        public void UpdateBookDescription_WhenExistingBook_ShouldUpdateDescription()
        {
            string existingBookTitle = "Book1";
            string newDescription = "New Description";

            _bookServices.UpdateBookDescription(existingBookTitle, newDescription);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == existingBookTitle);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(newDescription, updatedBook.Description);
        }

        [Test]
        public void UpdateBookDescription_WhenNonExistingBook_ShouldNotUpdateDescription()
        {
            string nonExistingBookTitle = "Non Existing Book";
            string newDescription = "New Description";

            _bookServices.UpdateBookDescription(nonExistingBookTitle, newDescription);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == nonExistingBookTitle);

            Assert.IsNull(updatedBook);
        }
        [Test]
        public void UpdateBookQuantity_WhenExistingBook_ShouldUpdateQuantity()
        {
            string existingBookTitle = "Book1";
            int newQuantity = 10;

            _bookServices.UpdateBookQuantity(existingBookTitle, newQuantity);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == existingBookTitle);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(newQuantity, updatedBook.Quantity);
        }

        [Test]
        public void UpdateBookQuantity_WhenNonExistingBook_ShouldNotUpdateQuantity()
        {
            string nonExistingBookTitle = "Non Existing Book";
            int newQuantity = 10;

            _bookServices.UpdateBookQuantity(nonExistingBookTitle, newQuantity);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == nonExistingBookTitle);

            Assert.IsNull(updatedBook);
        }
        [Test]
        public void UpdateBook_WhenExistingBook_ShouldUpdateBook()
        {
            string existingBookTitle = "Book1";
            string newTitle = "NewTitle";
            string newAuthor = "NewAuthor";
            string newDescription = "NewDescription";
            int newQuantity = 10;

            _bookServices.UpdateBook(existingBookTitle, newTitle, newAuthor, newDescription, newQuantity, _dbContext);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == newTitle);

            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(newTitle, updatedBook.Title);
            Assert.AreEqual(newAuthor, updatedBook.Author);
            Assert.AreEqual(newDescription, updatedBook.Description);
            Assert.AreEqual(newQuantity, updatedBook.Quantity);
        }

        [Test]
        public void UpdateBook_WhenNonExistingBook_ShouldNotUpdateBook()
        {
            string nonExistingBookTitle = "Non Existing Book";
            string newTitle = "NewTitle";
            string newAuthor = "NewAuthor";
            string newDescription = "NewDescription";
            int newQuantity = 10;

            _bookServices.UpdateBook(nonExistingBookTitle, newTitle, newAuthor, newDescription, newQuantity, _dbContext);

            var updatedBook = _dbContext.Books.FirstOrDefault(b => b.Title == newTitle);

            Assert.IsNull(updatedBook);
        }
        [Test]
        public void GetAllBooks_ShouldReturnAllBooks_WhenBooksExist()
        {
            var books = _bookServices.GetAllBooks();

            Assert.AreEqual(2, books.Count);
        }

        [Test]
        public void GetAllBooks_ShouldReturnEmptyList_WhenNoBooksExist()
        {

            _dbContext.Books.RemoveRange(_dbContext.Books);
            _dbContext.SaveChanges();

            var books = _bookServices.GetAllBooks();

            Assert.IsEmpty(books);
        }
    }
}

