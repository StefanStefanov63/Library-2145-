using Library.Services.ViewModelsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ILogServices
    {
        void TakeBook(string aBookTitle, string aLibraryCardName);
        void ReturnBook(string aBookTitle, string aLibraryCardName);
        ICollection<LogViewModel> GetAllLogsFromLibraryCardByName(string aName);
        ICollection<LogViewModel> GetAllLogs();
        ICollection<LogViewModel> GetAllLogsForBookByTitle(string aTitle);
    }
}
