using Library.Data;
using Library.Models;
using Library.Services.Classes;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Console
{
    using Azure;
    using Library.Services.ViewModelsClasses;
    using Microsoft.Win32;
    using System;
    public class Display
    {
        private int closeOperationId = 25;
        private readonly AuthorServices authorService;
        private readonly BookServices bookService;
        private readonly LibraryCardServices libraryCardService;
        private readonly LogServices logService;
        private readonly LibraryContext db;
        
        public Display()
        {
            this.db = new LibraryContext();
            db.Database.EnsureCreated();
            this.authorService = new AuthorServices(db);
            this.bookService = new BookServices(db);
            this.libraryCardService = new LibraryCardServices(db);
            this.logService = new LogServices(db);
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine("[1] Register new Library Card");
            Console.WriteLine("[2] Delete Librery Card by Name");
            Console.WriteLine("[3] Update Library Card's Name");
            Console.WriteLine("[4] Get all Librery Cards");
            Console.WriteLine("[5] Take Book");
            Console.WriteLine("[6] Return Book");
            Console.WriteLine("[7] Get all Logs");
            Console.WriteLine("[8] Get all Logs for Book");
            Console.WriteLine("[9] Get all Logs for Library Card");
            Console.WriteLine("[10] Register new Book");
            Console.WriteLine("[11] Delete Book");
            Console.WriteLine("[12] Update Book's Title");
            Console.WriteLine("[13] Update Book's Author");
            Console.WriteLine("[14] Update Book's Description");
            Console.WriteLine("[15] Update Book's Quantity");
            Console.WriteLine("[16] Update Whole Book");
            Console.WriteLine("[17] Get all Books");
            Console.WriteLine("[18] Get Book by Title");
            Console.WriteLine("[19] Get all Books by Author");
            Console.WriteLine("[20] Register new Author");
            Console.WriteLine("[21] Delete Author");
            Console.WriteLine("[22] Update Author's Name");
            Console.WriteLine("[23] Get all Authors");
            Console.WriteLine("[24] Clear Console");
            Console.WriteLine("[25] Exit");
        }
        private void Input() 
        {
            int operation = -1;
            do 
            { 
                ShowMenu();
                try
                {
                    operation = int.Parse(Console.ReadLine());
                }
                catch { }
                switch (operation)
                {
                    case 1:
                        RegisterNewLibraryCard();
                        break;
                    case 2:
                        DeleteLibraryCard();
                        break;
                    case 3:
                        UpdateLibraryCardName();
                        break;
                    case 4:
                        GetLibraryCards();
                        break;
                    case 5:
                        TakeBook();
                        break;
                    case 6:
                        ReturnBook();
                        break;
                    case 7:
                        GetAllLogs();
                        break;
                    case 8:
                        GetAllLogsForBookByTitle();
                        break;
                    case 9:
                        GetAllLogsFromLibraryCardByName();
                        break;
                    case 10:
                        RegisterNewBook();
                        break;
                    case 11:
                        DeleteBook();
                        break;
                    case 12:
                        UpdateBookTitle();
                        break;
                    case 13:
                        UpdateBookAuthor();
                        break;
                    case 14:
                        UpdateBookDescription();
                        break;
                    case 15:
                        UpdateBookQuantity();
                        break;
                    case 16:
                        UpdateWholeBook();
                        break;
                    case 17:
                        GetAllBooks();
                        break;
                    case 18:
                        GetBookByTitle();
                        break;
                    case 19:
                        GetAllBookByAuthor();
                        break;
                    case 20:
                        RegisterNewAuthor();
                        break;
                    case 21:
                        DeleteAuthor();
                        break;
                    case 22:
                        UpdateAuthorName();
                        break;
                    case 23:
                        GetAllAuthors();
                        break;
                    case 24:
                        Console.Clear();
                        break;
                    case 25:
                        Console.WriteLine("Thank you for using our program!");
                        break;
                    default:
                        Console.WriteLine("Incorect Input! Please enter the number in [] to use a comand");
                        break;
                }

            } while (operation != closeOperationId);
        }

        private void GetAllAuthors()
        {
            var allAuthors = authorService.GetAllAuthors();
            Console.WriteLine("[Id] --- [Name]");
            foreach (var anAuthor in allAuthors)
            {
                Console.WriteLine($"{anAuthor.Id} --- {anAuthor.Name}");
            }
        }

        private void UpdateAuthorName()
        {
            Console.WriteLine("Enter old Name:");
            string anOldName = Console.ReadLine();
            Console.WriteLine("Enter new Name:");
            string aNewName = Console.ReadLine();
            authorService.UpdateAuthorName(anOldName, aNewName);
        }

        private void DeleteAuthor()
        {
            Console.WriteLine("Enter Name:");
            string aName = Console.ReadLine();
            authorService.DeleteAuthorByName(aName);
        }

        private void RegisterNewAuthor()
        {
            Console.WriteLine("Enter Name:");
            string aName = Console.ReadLine();
            authorService.RegisterNewAuthor(aName);
        }

        private void GetAllBookByAuthor()
        {
            Console.WriteLine("Enter Book Author:");
            string anAuthor = Console.ReadLine();
            var allBooks = bookService.GetAllBookFromAuthor(anAuthor);
            if (allBooks != null)
            {
                Console.WriteLine("[Id] --- [Title] --- [Author] --- [Quantity]");
                Console.WriteLine($"[Description]");
                foreach (var aBook in allBooks)
                {
                    Console.WriteLine($"{aBook.Id} --- {aBook.Title} --- {aBook.Author}  --- {aBook.Quantity}");
                    Console.WriteLine(aBook.Description);
                }
            }
            else
            {
                Console.WriteLine($"Books by '{anAuthor.Trim()}' weren't found.");
            }
        }

        private void GetBookByTitle()
        {
            Console.WriteLine("Enter Book Title:");
            string aBookTitle = Console.ReadLine();
            var aBook = bookService.GetBookByTitle(aBookTitle);
            if (aBook != null)
            {
                Console.WriteLine("[Id] --- [Title] --- [Author] --- [Quantity]");
                Console.WriteLine($"[Description]");
                Console.WriteLine($"{aBook.Id} --- {aBook.Title} --- {aBook.Author} --- {aBook.Quantity}");
                Console.WriteLine(aBook.Description);
            }
            else
            {
                Console.WriteLine($"Book '{aBookTitle}' wasn't found.");
            }
        }

        private void GetAllBooks()
        {
            var allBooks = bookService.GetAllBooks();
            Console.WriteLine("[Id] --- [Title] --- [Author] --- [Quantity]");
            Console.WriteLine($"[Description]");
            foreach (var aBook in allBooks)
            {
                Console.WriteLine($"{aBook.Id} --- {aBook.Title} --- {aBook.Author} --- {aBook.Quantity}");
                Console.WriteLine(aBook.Description);
            }
        }

        private void UpdateWholeBook()
        {
            Console.WriteLine("Enter old Title:");
            string anOldTitle = Console.ReadLine();
            Console.WriteLine("Enter new Title:");
            string aNewTitle = Console.ReadLine();
            Console.WriteLine("Enter new Author:");
            string aNewAuthor = Console.ReadLine();
            Console.WriteLine("Enter new Description:");
            string aNewDescription = Console.ReadLine();
            Console.WriteLine("Enter new Quantity:");
            int aNewQuantity = int.Parse(Console.ReadLine());
            bookService.UpdateBook(anOldTitle, aNewTitle, aNewAuthor,aNewDescription, aNewQuantity,db);
        }

        private void UpdateBookQuantity()
        {
            try
            {
                Console.WriteLine("Enter Book Title:");
                string aTitle = Console.ReadLine();
                Console.WriteLine("Enter new Quantity:");
                int aNewQuantity = int.Parse(Console.ReadLine());
                bookService.UpdateBookQuantity(aTitle, aNewQuantity);
            }
            catch (FormatException ex)
            {
                Console.WriteLine( "Please enter only natural numbers");
            }

        }

        private void UpdateBookDescription()
        {
            Console.WriteLine("Enter Book Title:");
            string aTitle = Console.ReadLine();
            Console.WriteLine("Enter new Description:");
            string aNewDescription = Console.ReadLine();
            bookService.UpdateBookDescription(aTitle, aNewDescription);
        }

        private void UpdateBookAuthor()
        {
            Console.WriteLine("Enter Book Title:");
            string aTitle = Console.ReadLine();
            Console.WriteLine("Enter new Author:");
            string aNewAuthor = Console.ReadLine();
            bookService.UpdateBookAuthor(aTitle, aNewAuthor);
        }

        private void UpdateBookTitle()
        {
            Console.WriteLine("Enter old Title:");
            string anOldTitle = Console.ReadLine();
            Console.WriteLine("Enter new Title:");
            string aNewTitle = Console.ReadLine();
            bookService.UpdateBookTitle(anOldTitle, aNewTitle);
        }

        private void DeleteBook()
        {
            Console.WriteLine("Enter Book Title:");
            string aBookTitle = Console.ReadLine();
            bookService.DeleteBookByTitle(aBookTitle);
        }

        private void RegisterNewBook()
        {
            Console.WriteLine("Enter Title:");
            string aBookTitle = Console.ReadLine();
            Console.WriteLine("Enter Author:");
            string aBookAuthor = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string aBookDescription = Console.ReadLine();
            Console.WriteLine("Enter Quantity:");
            int aBookQuantity = int.Parse(Console.ReadLine());
            bookService.RegisterNewBook(aBookTitle, aBookAuthor, aBookDescription, aBookQuantity);
        }

        private void GetAllLogsFromLibraryCardByName()
        {
            Console.WriteLine("Enter Library Card's Name:");
            string aLibraryCardName = Console.ReadLine();
            var allLogs = logService.GetAllLogsFromLibraryCardByName(aLibraryCardName);
            if (allLogs != null)
            {
                Console.WriteLine("[Id] --- [Is Returned] --- [Book Title] --- [Library Card Name]");
                foreach (var aLog in allLogs)
                {
                    Console.WriteLine($"{aLog.Id} --- {aLog.IsReturned} --- {aLog.BookTitle} --- {aLog.LibraryCardName}");
                }
            }
            else 
            {
                Console.WriteLine($"Logs for '{aLibraryCardName}' weren't found.");
            }
        }

        private void GetAllLogsForBookByTitle()
        {
            Console.WriteLine("Enter Book Title:");
            string aBookTitle = Console.ReadLine();
            var allLogs = logService.GetAllLogsForBookByTitle(aBookTitle);
            if (allLogs != null)
            {

                Console.WriteLine("[Id] --- [Is Returned] --- [Book Title] --- [Library Card Name]");
                foreach (var aLog in allLogs)
                {
                    Console.WriteLine($"{aLog.Id} --- {aLog.IsReturned} --- {aLog.BookTitle} --- {aLog.LibraryCardName}");
                }
            }
            else
            {
                Console.WriteLine($"Logs for '{aBookTitle}' weren't found.");
            }
        }

        private void GetAllLogs()
        {
            var allLogs = logService.GetAllLogs();
            Console.WriteLine("[Id] --- [Is Returned] --- [Book Title] --- [Library Card Name]");
            foreach (var aLog in allLogs)
            {
                Console.WriteLine($"{aLog.Id} --- {aLog.IsReturned} --- {aLog.BookTitle} --- {aLog.LibraryCardName}");
            }
        }
        private void ReturnBook()
        {
            Console.WriteLine("Enter Book Title:");
            string aBookTitle = Console.ReadLine();
            Console.WriteLine("Enter Library Card's Name:");
            string aLibraryCardName = Console.ReadLine();
            logService.ReturnBook(aBookTitle, aLibraryCardName);
        }

        private void TakeBook()
        {
            Console.WriteLine("Enter Book Title:");
            string aBookTitle = Console.ReadLine();
            Console.WriteLine("Enter Library Card's Name:");
            string aLibraryCardName = Console.ReadLine();
            logService.TakeBook(aBookTitle, aLibraryCardName);
        }

        private void GetLibraryCards()
        {
            var allLibraryCards = libraryCardService.GetAllLibraryCards();
            Console.WriteLine("[Id] --- [Name]");
            foreach(var aLibraryCard in allLibraryCards) 
            {
                Console.WriteLine($"{aLibraryCard.Id} --- {aLibraryCard.Name}");
            }
        }

        private void UpdateLibraryCardName()
        {
            Console.WriteLine("Enter old Name:");
            string anOldName = Console.ReadLine();
            Console.WriteLine("Enter new Name:");
            string aNewName = Console.ReadLine();
            libraryCardService.UpdateLibraryCardName(anOldName, aNewName);
        }

        private void DeleteLibraryCard()
        {
            Console.WriteLine("Enter Name:");
            string aName = Console.ReadLine(); 
            libraryCardService.DeleteLibraryCardByName(aName);
        }

        private void RegisterNewLibraryCard()
        {
            Console.WriteLine("Enter Name:");
            string aName = Console.ReadLine();
            libraryCardService.RegisterNewLibraryCard(aName);
        }

    }
}
