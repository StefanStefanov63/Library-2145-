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
    public class LibraryCardServices : ILibraryCardServices
    {
        private readonly LibraryContext db;

        public LibraryCardServices(LibraryContext db)
        {
            this.db = db;
        }
        public void DeleteLibraryCardByName(string aName)
        {
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aName.Trim());
            if (aLibraryCard != null)
            {
                db.LibraryCards.Remove(aLibraryCard);
                Console.WriteLine($"LibraryCard for '{aName.Trim()}' was successfully removed, alongside it's logs.");

            }
            else
            {
                Console.WriteLine($"LibraryCard for '{aName.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }

        public ICollection<LibraryCardViewModel> GetAllLibraryCards()
        {
            var aLibraryCards = db.LibraryCards.ToList();
            var allLibraryCards = new List<LibraryCardViewModel>();
            foreach( var aLibraryCard in aLibraryCards)
            { 
                LibraryCardViewModel aLibraryCardViewModel = new LibraryCardViewModel();
                aLibraryCardViewModel.Id = aLibraryCard.Id;
                aLibraryCardViewModel.Name = aLibraryCard.Name;
                allLibraryCards.Add(aLibraryCardViewModel);
            }
            return allLibraryCards;
        }

        public void RegisterNewLibraryCard(string aName)
        {
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aName.Trim());
            if (aLibraryCard == null)
            {
                LibraryCard libraryCard = new LibraryCard();
                libraryCard.Name = aName.Trim();
                db.LibraryCards.Add(libraryCard);
                Console.WriteLine($"LibraryCard for '{aName.Trim()}' was successfully registered.");
            }
            else
            {
                Console.WriteLine($"LibraryCard for '{aName.Trim()}' is already registered.");
            }
            db.SaveChanges();
        }
        public void UpdateLibraryCardName(string aOldName, string aNewName)
        {
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aOldName.Trim());
            if (aLibraryCard != null)
            {
                aLibraryCard.Name = aNewName.Trim();
                Console.WriteLine($"LibraryCard for '{aOldName.Trim()}' was successfully renamed to '{aNewName.Trim()}'.");
            }
            else
            {
                Console.WriteLine($"LibraryCard for '{aOldName.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }
    }
}
