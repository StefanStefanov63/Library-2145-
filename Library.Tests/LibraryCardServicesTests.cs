using NUnit.Framework;
using Library.Services.Classes;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Library.Services.Interfaces;

namespace Library.Tests
{
    [TestFixture]
    public class LibraryCardServicesTests
    {
        private LibraryContext _dbContext;
        private ILibraryCardServices _libraryCardServices;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new LibraryContext(options);
            _libraryCardServices = new LibraryCardServices(_dbContext);

            SeedTestData();
        }

        [Test]
        public void RegisterNewLibraryCard_WhenNewCard_ShouldAddToDatabase()
        {
            string cardName = "John Doe";

            _libraryCardServices.RegisterNewLibraryCard(cardName);
            var cards = _libraryCardServices.GetAllLibraryCards();

            Assert.IsTrue(cards.Any(c => c.Name == cardName));
        }

        [Test]
        public void RegisterNewLibraryCard_WhenExistingCard_ShouldNotAddToDatabase()
        {
            _libraryCardServices.RegisterNewLibraryCard("Card1");
            var cards = _libraryCardServices.GetAllLibraryCards();

            Assert.AreEqual(3, cards.Count);
        }

        [Test]
        public void DeleteLibraryCard_WhenExistingCard_ShouldRemoveFromDatabase()
        {
            string cardName = "Card to Delete";
            _libraryCardServices.RegisterNewLibraryCard(cardName);

            _libraryCardServices.DeleteLibraryCardByName(cardName);
            var cards = _libraryCardServices.GetAllLibraryCards();

            Assert.IsFalse(cards.Any(c => c.Name == cardName));
        }

        [Test]
        public void DeleteLibraryCard_WhenNonExistingCard_ShouldNotRemoveFromDatabase()
        {
            string nonExistingCardName = "Non Existing Card";

            _libraryCardServices.DeleteLibraryCardByName(nonExistingCardName);
            var cards = _libraryCardServices.GetAllLibraryCards();

            Assert.AreEqual(0, cards.Count(c => c.Name == nonExistingCardName));
        }

        [Test]
        public void GetAllLibraryCards_ShouldReturnAllCards_WhenCardsExist()
        {
            var cards = _libraryCardServices.GetAllLibraryCards();

            Assert.AreEqual(3, cards.Count);
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

            _dbContext.SaveChanges();
        }
    }
}