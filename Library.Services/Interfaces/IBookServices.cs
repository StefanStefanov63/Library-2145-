using Library.Data;
using Library.Models;
using Library.Services.ViewModelsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookServices
    {
        void RegisterNewBook(string aTitle, string anAuthor, string aDescription, int aQuantity);
        void DeleteBookByTitle(string aTitle);
        void UpdateBookTitle(string anOldTitle, string aNewTitle);
        void UpdateBookAuthor(string aTitle, string aNewAuthor);
        void UpdateBookDescription(string aTitle, string aNewDescription);
        void UpdateBookQuantity(string aTitle, int aNewQuantity);
        void UpdateBook(string anOldTitle, string aNewTitle, string aNewAuthor, string aNewDescription, int aNewQuantity, LibraryContext db);
        ICollection<BookViewModel> GetAllBooks();
        BookViewModel GetBookByTitle(string aTitle);
        ICollection<BookViewModel> GetAllBookFromAuthor(string amAuthor);
    }
}
