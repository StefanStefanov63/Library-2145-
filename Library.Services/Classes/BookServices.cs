using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Library.Services.ViewModelsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Classes
{
    public class BookServices : IBookServices
    {
        private readonly LibraryContext db;

        public BookServices(LibraryContext db)
        {
            this.db = db;
        }
        public void DeleteBookByTitle(string aTitle)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aTitle.Trim());
            if (aBook != null)
            {
                db.Books.Remove(aBook);
                Console.WriteLine($"Book '{aTitle.Trim()}' was successfully removed.");

            }
            else
            {
                Console.WriteLine($"Book '{aTitle.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }

        public ICollection<BookViewModel> GetAllBookFromAuthor(string amAuthor)
        {
            var aBooks = db.Books.ToList();
            var allBooks = new List<BookViewModel>();
            foreach (var aBook in aBooks)
            { 
                string anAuthorName = db.Authors.FirstOrDefault(x => x.Id == aBook.AuthorId).Name;
                if (anAuthorName== amAuthor)
                {
                    BookViewModel aBookViewModel = new BookViewModel();
                    aBookViewModel.Id = aBook.Id;
                    aBookViewModel.Title = aBook.Title;
                    aBookViewModel.Description = aBook.Description;
                    aBookViewModel.Quantity = aBook.Quantity;
                    aBookViewModel.Author = anAuthorName;
                    allBooks.Add(aBookViewModel);
                }
            }
            return allBooks;
        }

        public ICollection<BookViewModel> GetAllBooks()
        {
            var aBooks = db.Books.ToList();
            var allBooks = new List<BookViewModel>();
            foreach (var aBook in aBooks)
            {
                BookViewModel aBookViewModel = new BookViewModel();
                aBookViewModel.Id = aBook.Id;
                aBookViewModel.Title = aBook.Title;
                aBookViewModel.Description= aBook.Description;
                aBookViewModel.Quantity = aBook.Quantity;
                aBookViewModel.Author = db.Authors.FirstOrDefault(x => x.Id == aBook.AuthorId).Name;
                allBooks.Add(aBookViewModel);
            }
            return allBooks;
        }

        public void RegisterNewBook(string aTitle, string anAuthorName, string aDescription, int aQuantity)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aTitle.Trim());
            if (aBook == null)
            {
                Book book = new Book();
                book.Title = aTitle.Trim();
                book.Description = aDescription.Trim();
                if (aQuantity > 0)
                { 
                    book.Quantity = aQuantity;
                }
                else
                {
                    book.Quantity = 0;
                    Console.WriteLine($"Book Quantity: {aQuantity} wasn't above 0, so it was registered as 0");
                }
                var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == anAuthorName.Trim());
                if (anAuthor == null)
                {
                    anAuthor = new Author{Name = anAuthorName.Trim()};
                    db.Authors.Add(anAuthor);
                    db.SaveChanges();
                    Console.WriteLine($"An Author by the name '{anAuthorName.Trim()}' wasn't found, so was registered");
                    book.AuthorId = db.Authors.FirstOrDefault(x => x.Name.Trim() == anAuthorName.Trim()).Id;
                }
                else
                {
                    Console.WriteLine($"Book '{aTitle.Trim()}' was successfully registered.");
                    book.AuthorId = anAuthor.Id;
                }
                db.Books.Add(book);
                
            }
            else
            {
                Console.WriteLine($"Book by the title of '{aTitle.Trim()}' is already registered.");
            }
            db.SaveChanges();
        }

        public BookViewModel GetBookByTitle(string aTitle)
        {
            var aBookViewModel = new BookViewModel();
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aTitle.Trim());
            if (aBook != null)
            {
                aBookViewModel.Id = aBook.Id;
                aBookViewModel.Title = aBook.Title.Trim();
                aBookViewModel.Description = aBook.Description;
                aBookViewModel.Quantity = aBook.Quantity;
                aBookViewModel.Author = db.Authors.FirstOrDefault(x => x.Id == aBook.AuthorId).Name;
                return aBookViewModel;
            }
            return null;
        }

        public void UpdateBook(string anOldTitle, string aNewTitle, string aNewAuthor, string aNewDescription, int aNewQuantity, LibraryContext db)
        {
            var aBookServices = new BookServices(db);
            if (db.Books.FirstOrDefault(x => x.Title.Trim() == anOldTitle.Trim()) == null)
            {
                Console.WriteLine($"Book '{anOldTitle.Trim()}' wasn't found.");
            }
            else
            {
                aBookServices.UpdateBookTitle(anOldTitle, aNewTitle);
                aBookServices.UpdateBookAuthor(aNewTitle, aNewAuthor);
                aBookServices.UpdateBookDescription(aNewTitle, aNewDescription);
                aBookServices.UpdateBookQuantity(aNewTitle, aNewQuantity);
            }
            
        }

        public void UpdateBookAuthor(string aTitle, string aNewAuthor)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aTitle.Trim());
            if (aBook != null)
            {
                var anOldAuthor = db.Authors.FirstOrDefault(x => x.Id == aBook.AuthorId);
                var anNewAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aNewAuthor.Trim());
                if (anNewAuthor == null)
                {
                    anNewAuthor = new Author { Name = aNewAuthor.Trim() };
                    db.Authors.Add(anNewAuthor);
                    db.SaveChanges();
                    Console.WriteLine($"An Author by the name '{aNewAuthor.Trim()}' wasn't found, so was registered");
                    aBook.AuthorId = db.Authors.FirstOrDefault(x => x.Name.Trim() == aNewAuthor.Trim()).Id;
                }
                else
                {
                    Console.WriteLine($"Book '{aTitle.Trim()}''s Author was successfully changed from {anOldAuthor.Name.Trim()} to {aNewAuthor.Trim()}.");
                    aBook.AuthorId = anNewAuthor.Id;
                }
            }
            else
            {
                Console.WriteLine($"Book '{aTitle.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }

        public void UpdateBookDescription(string aTitle, string aNewDescription)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aTitle.Trim());
            if (aBook != null)
            {
                Console.WriteLine($"Book '{aTitle.Trim()}''s Description was successfully changed from '{aBook.Description.Trim()}' to '{aNewDescription.Trim()}'.");
                aBook.Description = aNewDescription;
            }
            else
            {
                Console.WriteLine($"Book '{aTitle.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }

        public void UpdateBookQuantity(string aTitle, int aNewQuantity)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aTitle.Trim());
            if (aBook != null)
            {
                if(aNewQuantity>=0)
                {
                    Console.WriteLine($"Book '{aTitle.Trim()}''s Quantity was successfully changed from {aBook.Quantity} to {aNewQuantity}.");
                    aBook.Quantity = aNewQuantity;
                }
                else
                {
                    Console.WriteLine($"The new Quantity {aNewQuantity} is below 0, so it wasn't changed");
                }
                
            }
            else
            {
                Console.WriteLine($"Book '{aTitle.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }

        public void UpdateBookTitle(string anOldTitle, string aNewTitle)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == anOldTitle.Trim());
            if (aBook != null)
            {
                aBook.Title = aNewTitle.Trim();
                Console.WriteLine($"Book '{anOldTitle.Trim()}' was successfully renamed to '{aNewTitle.Trim()}'.");
            }
            else
            {
                Console.WriteLine($"Book '{anOldTitle.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }
    }
}
