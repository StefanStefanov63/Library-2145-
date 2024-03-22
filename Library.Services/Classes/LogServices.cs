using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Library.Services.ViewModelsClasses;

namespace Library.Services.Classes
{
    public class LogServices : ILogServices
    {
        private readonly LibraryContext db;

        public LogServices(LibraryContext db)
        {
            this.db = db;
        }

        public ICollection<LogViewModel> GetAllLogs()
        {
            var aLogs = db.Logs.ToList();
            var allLogs = new List<LogViewModel>();
            foreach (var aLog in aLogs)
            {
                LogViewModel aLogViewModel = new LogViewModel();
                aLogViewModel.Id = aLog.Id;
                aLogViewModel.IsReturned = aLog.IsReturned;
                aLogViewModel.BookTitle = db.Books.FirstOrDefault(x => x.Id == aLog.BookId).Title;
                aLogViewModel.LibraryCardName = db.LibraryCards.FirstOrDefault(x => x.Id == aLog.LibraryCardId).Name;
                allLogs.Add(aLogViewModel);
            }
            return allLogs;
        }

        public ICollection<LogViewModel> GetAllLogsForBookByTitle(string aTitle)
        {
            var aLogs = db.Logs.ToList();
            var allLogs = new List<LogViewModel>();
            foreach (var aLog in aLogs)
            {
                string aLogBookTitle = db.Books.FirstOrDefault(x => x.Id == aLog.BookId).Title;
                if (aLogBookTitle == aTitle )
                {
                    LogViewModel aLogViewModel = new LogViewModel();
                    aLogViewModel.Id = aLog.Id;
                    aLogViewModel.IsReturned = aLog.IsReturned;
                    aLogViewModel.BookTitle = aLogBookTitle;
                    aLogViewModel.LibraryCardName = db.LibraryCards.FirstOrDefault(x => x.Id == aLog.LibraryCardId).Name;
                    allLogs.Add(aLogViewModel);
                }
                
            }
            return allLogs;
        }

        public ICollection<LogViewModel> GetAllLogsFromLibraryCardByName(string aName)
        {
            var aLogs = db.Logs.ToList();
            var allLogs = new List<LogViewModel>();
            foreach (var aLog in aLogs)
            {
                string aLogLibraryCardName = db.LibraryCards.FirstOrDefault(x => x.Id == aLog.LibraryCardId).Name;
                if (aLogLibraryCardName == aName)
                {
                    LogViewModel aLogViewModel = new LogViewModel();
                    aLogViewModel.Id = aLog.Id;
                    aLogViewModel.IsReturned = aLog.IsReturned;
                    aLogViewModel.BookTitle = db.Books.FirstOrDefault(x => x.Id == aLog.BookId).Title;
                    aLogViewModel.LibraryCardName = aLogLibraryCardName;
                    allLogs.Add(aLogViewModel);
                }

            }
            return allLogs;
        }

        public void ReturnBook(string aBookTitle, string aLibraryCardName)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aLibraryCardName.Trim());
            if (aBook == null && aLibraryCard == null)
            {

                Console.WriteLine($"Both Book '{aBookTitle.Trim()}' and LibraryCard for '{aLibraryCardName.Trim()}' weren't found.");
            }
            else if (aBook == null)
            {
                Console.WriteLine($"Book '{aBookTitle.Trim()}' wasn't found.");
            }
            else if (aLibraryCard == null)
            {
                Console.WriteLine($"LibraryCard for '{aLibraryCardName.Trim()}' wasn't found.");
            }
            else
            {
                var aLog = db.Logs.FirstOrDefault(x => x.BookId == aBook.Id && x.LibraryCardId == aLibraryCard.Id && x.IsReturned == false) ;
                if (aLog == null)
                {
                    Console.WriteLine($"An unreturned log with this Book '{aBookTitle.Trim()}' and taken by '{aLibraryCardName.Trim()}' wasn't found.");
                }
                else 
                {
                    aLog.IsReturned = true;
                    aBook.Quantity++;
                    Console.WriteLine($"'{aLibraryCardName.Trim()}' has returned a copy of '{aBookTitle.Trim()}'.");
                }
            }
            db.SaveChanges();
        }

        public void TakeBook(string aBookTitle, string aLibraryCardName)
        {
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aLibraryCardName.Trim());
            if (aBook == null && aLibraryCard == null)
            {
                
                Console.WriteLine($"Both Book '{aBookTitle.Trim()}' and LibraryCard for '{aLibraryCardName.Trim()}' weren't found.");
            }
            else if(aBook == null)
            {
                Console.WriteLine($"Book '{aBookTitle.Trim()}' wasn't found.");
            }
            else if (aLibraryCard == null)
            {
                Console.WriteLine($"LibraryCard for '{aLibraryCardName.Trim()}' wasn't found.");
            }
            else
            {
                if (aBook.Quantity > 0) 
                {
                    aBook.Quantity --;
                    Log log = new Log();
                    log.IsReturned = false;
                    log.BookId = aBook.Id;
                    log.LibraryCardId = aLibraryCard.Id;
                    db.Logs.Add(log);
                    Console.WriteLine($"'{aLibraryCardName.Trim()}' has successfully taken a copy of '{aBookTitle.Trim()}'.");
                }
                else
                {
                    Console.WriteLine($"There aren't any available copies of '{aBookTitle.Trim()}'.");
                }
            }
            db.SaveChanges();
        }
    }
}
