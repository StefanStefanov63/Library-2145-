using NUnit.Framework;
using Library.Services.Classes;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Library.Services.Interfaces;
using System.Reflection;

namespace Library.Tests
{
    [TestFixture]
    public class LogServicesTests
    {
        private LibraryContext _dbContext;
        private ILogServices _logServices;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new LibraryContext(options);
            _logServices = new LogServices(_dbContext);
        }

        [Test]
        public void GetAllLogs_ShouldReturnAllLogs_WhenLogsExist()
        {
            var logs = _logServices.GetAllLogs();

            Assert.IsNotNull(logs);
            Assert.AreEqual(3, logs.Count);
        }

        [Test]
        public void GetAllLogs_ShouldReturnEmptyList_WhenLogsDoNotExist()
        {
            _dbContext.Logs.RemoveRange(_dbContext.Logs);
            _dbContext.SaveChanges();

            var logs = _logServices.GetAllLogs();

            Assert.IsNotNull(logs);
            Assert.IsEmpty(logs);
        }

        [Test]
        public void GetAllLogsForBookByTitle_ShouldReturnAllLogsForBook_WhenLogsExist()
        {
            string bookTitle = "Book1";
            var logs = _logServices.GetAllLogsForBookByTitle(bookTitle);

            Assert.IsNotNull(logs);
            Assert.AreEqual(2, logs.Count);
            Assert.IsTrue(logs.All(l => l.BookTitle == bookTitle));
        }

        [Test]
        public void GetAllLogsForBookByTitle_ShouldReturnEmptyList_WhenLogsDoNotExistForBook()
        {
            string nonExistingBookTitle = "Non Existing Book";
            var logs = _logServices.GetAllLogsForBookByTitle(nonExistingBookTitle);

            Assert.IsNotNull(logs);
            Assert.IsEmpty(logs);
        }

        [Test]
        public void GetAllLogsFromLibraryCardByName_ShouldReturnAllLogsForLibraryCard_WhenLogsExist()
        {
            string libraryCardName = "Card1";
            var logs = _logServices.GetAllLogsFromLibraryCardByName(libraryCardName);

            Assert.IsNotNull(logs);
            Assert.AreEqual(2, logs.Count);
            Assert.IsTrue(logs.All(l => l.LibraryCardName == libraryCardName));
        }

        [Test]
        public void GetAllLogsFromLibraryCardByName_ShouldReturnEmptyList_WhenLogsDoNotExistForLibraryCard()
        {
            string nonExistingLibraryCardName = "Non Existing Card";
            var logs = _logServices.GetAllLogsFromLibraryCardByName(nonExistingLibraryCardName);

            Assert.IsNotNull(logs);
            Assert.IsEmpty(logs);
        }

        private void SeedTestData()
        {
            _dbContext.LibraryCards.AddRange(
                new Models.LibraryCard { Name = "Card1" },
                new Models.LibraryCard { Name = "Card2" },
                new Models.LibraryCard { Name = "Card3" }
            );

            _dbContext.Books.AddRange(
                new Models.Book { Title = "Book1", Quantity = 3 },
                new Models.Book { Title = "Book2", Quantity = 1 },
                new Models.Book { Title = "Book3", Quantity = 5 }
            );

            _dbContext.Logs.AddRange(
                new Models.Log { BookId = 1, LibraryCardId = 1 },
                new Models.Log { BookId = 1, LibraryCardId = 1 },
                new Models.Log { BookId = 2, LibraryCardId = 2 }
            );

            _dbContext.SaveChanges();
        }
    }
}