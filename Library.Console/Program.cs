using Library.Console;
using Library.Data;
using Library.Services.Classes;
using Library.Services.ViewModelsClasses;

internal class Program
{
    private static void Main(string[] args)
    {

        Display display = new Display();
        //var db = new LibraryContext();
        //db.Database.EnsureCreated();
        Console.WriteLine();

        /*
         liberary card & log
        1 create new library card
        2 delete librery card( by name)
        3 Update/change liberary card
        4 view all librery cards
        5 fetch specific libary card's log
        21 get librery card by name

        6 crate new log(book name, liberary card name)
        7 delete specific log(by id)
        8 return book
        9 see all logs

         book 
        10 add new book
        11 delete book(by name)
        12 update/change book  /name,author,description,qunatity,whole
        13 see all books
        14 find book by title
        15 find all books by author
        16 see all logs of a certain book

        17 add new author
        18 update/change author
        19 delete author(if there are no books by them, by name)
         get all authors
        20 exit
         */
        //AuthorServices ab = new AuthorServices(db);
        //ab.RegisterNewAuthor("TK523");
        //AuthorViewModel a = new AuthorViewModel();
        //a = ab.GetAuthorByName("oldcat");
        //Console.WriteLine($"{a.Id} {a.Name}");

    }
}