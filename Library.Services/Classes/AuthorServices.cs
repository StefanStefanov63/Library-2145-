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
    public class AuthorServices : IAuthorServices
    {
        private readonly LibraryContext db;

        public AuthorServices(LibraryContext db)
        {
            this.db = db;
        }
        public void DeleteAuthorByName(string aName)
        {
            var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aName.Trim());
            if (anAuthor != null)
            {   
                var aBook = db.Books.FirstOrDefault( x => x.AuthorId == anAuthor.Id);
                if(aBook != null)
                {
                    Console.WriteLine($"Author '{aName.Trim()}' has registered book/s, so wasn't removed.");
                }
                else
                {
                    db.Authors.Remove(anAuthor);
                    Console.WriteLine($"Author '{aName.Trim()}' doesn't have registered book/s, so was removed.");
                }
                
            }
            else
            {
                Console.WriteLine($"Author '{aName.Trim()}' wasn't found.");
            }
            db.SaveChanges();
        }

        public ICollection<AuthorViewModel> GetAllAuthors()
        {
            var anAuthors = db.Authors.ToList();
            var allAuthors = new List<AuthorViewModel>();
            foreach (var Author in anAuthors)
            {
                AuthorViewModel anAuthorViewModel = new AuthorViewModel();
                anAuthorViewModel.Id = Author.Id;
                anAuthorViewModel.Name = Author.Name;
                allAuthors.Add(anAuthorViewModel);
            }
            return allAuthors;
        }

        public void RegisterNewAuthor(string aName)
        {
            var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aName.Trim());
            if(aName == "")
            {
                Console.WriteLine($"Name '{aName.Trim()}' is empty, so wan't registered.");
            }
            else if (anAuthor == null) 
            { 
                Author author = new Author();
                author.Name = aName.Trim();
                db.Authors.Add(author);
                Console.WriteLine($"Author '{aName.Trim()}' was successfully registered.");
            }
            else
            {
                Console.WriteLine($"Author '{aName.Trim()}' is already registered.");
            }
            db.SaveChanges();
        }

        public void UpdateAuthorName(string aOldName, string aNewName)
        {
            var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aOldName.Trim());
            if (anAuthor != null)
            {
                anAuthor.Name = aNewName.Trim();
                Console.WriteLine($"Author '{aOldName.Trim()}' was successfully renamed to '{aNewName.Trim()}'.");
            }
            else if(anAuthor == null)
            {
                Console.WriteLine($"Author '{aOldName.Trim()}' wasn't found.");
            }
            else if(aNewName == "")
            {
                Console.WriteLine($"New Name '{aNewName.Trim()}' is empty, so wan't registered.");
            }
            db.SaveChanges();
        }
    }
}
