using Library.Services.ViewModelsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IAuthorServices
    {
        void RegisterNewAuthor(string aName);
        void DeleteAuthorByName(string aName);
        void UpdateAuthorName(string aOldName, string aNewName);
        ICollection<AuthorViewModel> GetAllAuthors();
    }
}
