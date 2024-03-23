using Library.Data;
using Library.Models;
using Library.Services.Classes;
using Library.Services.ViewModelsClasses;

namespace Library.Forms
{
    public partial class LibaryForm : Form
    {
        private readonly AuthorServices authorService;
        private readonly BookServices bookService;
        private readonly LibraryCardServices libraryCardService;
        private readonly LogServices logService;
        private readonly LibraryContext db;
        public LibaryForm()
        {
            this.db = new LibraryContext();
            db.Database.EnsureCreated();
            this.authorService = new AuthorServices(db);
            this.bookService = new BookServices(db);
            this.libraryCardService = new LibraryCardServices(db);
            this.logService = new LogServices(db);
            InitializeComponent();
        }

        private void comboBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            switch (comboBoxCommands.SelectedIndex)
            {
                case 0:
                    ShowLabelAndBoxes("Enter Name:");
                    break;
                case 1:
                    ShowLabelAndBoxes("Enter Name:");
                    break;
                case 2:
                    ShowLabelAndBoxes("Enter OLd Name:","Enter New Name:");
                    break;
                case 3:
                    GetLibraryCards();
                    break;
                case 4:
                    ShowLabelAndBoxes("Enter Book Title:", "Enter Library Card Name:");
                    break;
                case 5:
                    ShowLabelAndBoxes("Enter Book Title:", "Enter Library Card Name:");
                    break;
                case 6:
                    GetAllLogs();
                    break;
                case 7:
                    ShowLabelAndBoxes("Enter Book Title:");
                    break;
                case 8:
                    ShowLabelAndBoxes("Enter Library Card Name:");
                    break;
                case 9:
                    ShowLabelAndBoxes("Enter Title:","Enter Author:","Enter Description:","Enter Quantity:");
                    break;
                case 10:
                    ShowLabelAndBoxes("Enter Book Title:");
                    break;
                case 11:
                    ShowLabelAndBoxes("Enter Old Title:", "Enter New Title:");
                    break;
                case 12:
                    ShowLabelAndBoxes("Enter Title:", "Enter New Author:");
                    break;
                case 13:
                    ShowLabelAndBoxes("Enter Title:", "Enter New Description:");
                    break;
                case 14:
                    ShowLabelAndBoxes("Enter Title:", "Enter New Quantity:");
                    break;
                case 15:
                    ShowLabelAndBoxes("Enter Old Title:", "Enter New Title:", "Enter New Author:", "Enter New Description:", "Enter New Quantity:");
                    break;
                case 16:
                    GetAllBooks();
                    break;
                case 17:
                    ShowLabelAndBoxes("Enter Title:");
                    break;
                case 18:
                    ShowLabelAndBoxes("Enter Name:");
                    break;
                case 19:
                    ShowLabelAndBoxes("Enter Name:");
                    break;
                case 20:
                    ShowLabelAndBoxes("Enter Name:");
                    break;
                case 21:
                    ShowLabelAndBoxes("Enter OLd Name:", "Enter New Name:");
                    break;
                case 22:
                    GetAllAuthors();
                    break;
                case 23:
                    Close();
                    break;
                default:
                    break;
            }
        }
        private void ShowLabelAndBoxes(string aFirstLine)
        {
            label1.Visible = true;
            label1.Enabled = true;
            label1.Text = aFirstLine;
            textBox1.Visible = true;
            textBox1.Enabled = true;
        }
        private void ShowLabelAndBoxes(string aFirstLine,string aSecondLine)
        {
            ShowLabelAndBoxes(aFirstLine);
            label2.Visible = true;
            label2.Enabled = true;
            label2.Text = aSecondLine;
            textBox2.Visible = true;
            textBox2.Enabled = true;
        }
        private void ShowLabelAndBoxes(string aFirstLine, string aSecondLine,string aThirdLine)
        {
            ShowLabelAndBoxes(aFirstLine, aSecondLine);
            label3.Visible = true;
            label3.Enabled = true;
            label3.Text = aThirdLine;
            textBox3.Visible = true;
            textBox3.Enabled = true;
        }
        private void ShowLabelAndBoxes(string aFirstLine, string aSecondLine, string aThirdLine, string aFourthLine)
        {
            ShowLabelAndBoxes(aFirstLine, aSecondLine, aThirdLine);
            label4.Visible = true;
            label4.Enabled = true;
            label4.Text = aFourthLine;
            textBox4.Visible = true;
            textBox4.Enabled = true;
        }
        private void ShowLabelAndBoxes(string aFirstLine, string aSecondLine, string aThirdLine, string aFourthLine, string aFifthLine)
        {
            ShowLabelAndBoxes(aFirstLine, aSecondLine, aThirdLine, aFourthLine);
            label5.Visible = true;
            label5.Enabled = true;
            label5.Text = aFifthLine;
            textBox5.Visible = true;
            textBox5.Enabled = true;
        }
        private void EnableDateGridView1()
        {
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
        }

        private void Clear()
        {
            label1.Visible = false;
            label1.Enabled = false;
            label2.Visible = false;
            label2.Enabled = false;
            label3.Visible = false;
            label3.Enabled = false;
            label4.Visible = false;
            label4.Enabled = false;
            label5.Visible = false;
            label5.Enabled = false;
            textBox1.Visible = false;
            textBox1.Enabled = false;
            textBox2.Visible = false;
            textBox2.Enabled = false;
            textBox3.Visible = false;
            textBox3.Enabled = false;
            textBox4.Visible = false;
            textBox4.Enabled = false;
            textBox5.Visible = false;
            textBox5.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView1.Enabled = false;
        }

        private void LibaryForm_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            switch (comboBoxCommands.SelectedIndex)
            {
                case 0:
                    RegisterNewLibraryCard();
                    break;
                case 1:
                    DeleteLibraryCard();
                    break;
                case 2:
                    UpdateLibraryCardName();
                    break;
                case 4:
                    TakeBook();
                    break;
                case 5:
                    ReturnBook();
                    break;
                case 7:
                    GetAllLogsForBookByTitle();
                    break;
                case 8:
                    GetAllLogsFromLibraryCardByName();
                    break;
                case 9:
                    RegisterNewBook();
                    break;
                case 10:
                    DeleteBook();
                    break;
                case 11:
                    UpdateBookTitle();
                    break;
                case 12:
                    UpdateBookAuthor();
                    break;
                case 13:
                    UpdateBookDescription();
                    break;
                case 14:
                    UpdateBookQuantity();
                    break;
                case 15:
                    UpdateWholeBook();
                    break;
                case 17:
                    GetBookByTitle();
                    break;
                case 18:
                    GetAllBookByAuthor();
                    break;
                case 19:
                    RegisterNewAuthor();
                    break;
                case 20:
                    DeleteAuthor();
                    break;
                case 21:
                    UpdateAuthorName();
                    break;
                case 23:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void GetAllAuthors()
        {
            EnableDateGridView1();
            dataGridView1.DataSource = authorService.GetAllAuthors();
        }

        private void UpdateAuthorName()
        {
            string anOldName = textBox1.Text;
            string aNewName = textBox2.Text;
            var aBook = db.Authors.FirstOrDefault(x => x.Name.Trim() == anOldName.Trim());
            if (aBook == null)
            {
                labelCommands.Text = $"Author '{anOldName.Trim()}' wasn't found.";
            }
            else if (aNewName == "")
            {
                labelCommands.Text = $"New Author '{aNewName.Trim()}' is empty, so wan't registered.";
            }
            else
            {
                authorService.UpdateAuthorName(anOldName, aNewName);
                labelCommands.Text = $"Author '{anOldName.Trim()}' was successfully renamed to '{aNewName.Trim()}'.";
            }
        }

        private void DeleteAuthor()
        {
            string anAuthorName = textBox1.Text;
            var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == anAuthorName.Trim());
            if (anAuthor != null)
            {
                var aBook = db.Books.FirstOrDefault(x => x.AuthorId == anAuthor.Id);
                if (aBook != null)
                {
                    labelCommands.Text = $"Author '{anAuthorName.Trim()}' has registered book/s, so wasn't removed.";
                }
                else
                {
                    authorService.DeleteAuthorByName(anAuthorName);
                    labelCommands.Text = $"Author '{anAuthorName.Trim()}' doesn't have registered book/s, so was removed.";
                }
            }
            else
            {
                labelCommands.Text = $"Author '{anAuthorName.Trim()}' wasn't found.";
            }
        }

        private void RegisterNewAuthor()
        {
            string anAuthorName = textBox1.Text;
            var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == anAuthorName.Trim());
            if (anAuthor != null)
            {
                labelCommands.Text = $"Author '{anAuthorName.Trim()}' is already registered.";
            }
            else if (anAuthorName == "")
            {
                labelCommands.Text = $"Author '{anAuthorName.Trim()}' is empty, so wan't registered.";
            }
            else
            {
                authorService.RegisterNewAuthor(anAuthorName);
                labelCommands.Text = $"Author '{anAuthorName.Trim()}' was successfully registered.";
            }
        }

        private void GetAllBookByAuthor()
        {
            string anAuthor = textBox1.Text;
            var aBook = bookService.GetAllBookFromAuthor(anAuthor);
            if (aBook == null)
            {
                labelCommands.Text = $"Books by '{anAuthor.Trim()}' weren't found.";
            }
            else
            {
                EnableDateGridView1();
                dataGridView1.DataSource = aBook;
            }
        }

        private void GetBookByTitle()
        {
            string aBookTitle = textBox1.Text;
            BookViewModel aBook = bookService.GetBookByTitle(aBookTitle);
            if(aBook == null)
            {
                labelCommands.Text = $"Book '{aBookTitle.Trim()}' wasn't found.";
            }
            else
            {
                EnableDateGridView1();
                var aBooks = new List<BookViewModel> { aBook };
                dataGridView1.DataSource = aBooks;
            }
        }

        private void GetAllBooks()
        {
            EnableDateGridView1();
            dataGridView1.DataSource = bookService.GetAllBooks();
        }

        private void UpdateWholeBook()
        {
            labelCommands.Text = "";
            string anOldTitle = textBox1.Text;
            string aNewTitle = textBox2.Text;
            string aNewAuthor = textBox3.Text;
            string aNewDescription = textBox4.Text;
            int aNewQuantity = 0;
            try
            {
                aNewQuantity = int.Parse(textBox5.Text);
                var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == anOldTitle.Trim());
                if (aBook == null)
                {
                    labelCommands.Text = $"Book '{anOldTitle.Trim()}' wasn't found.";
                }
                else if (aNewTitle == "")
                {
                    labelCommands.Text = $"New Title '{aNewTitle.Trim()}' is empty, so wan't registered.";
                }
                else if (aNewAuthor == "")
                {
                    labelCommands.Text = $"New Author '{aNewAuthor.Trim()}' is empty, so wan't registered.";
                }
                else
                {
                    bookService.UpdateBookTitle(anOldTitle, aNewTitle);
                    labelCommands.Text = $"Book '{anOldTitle.Trim()}' was successfully renamed to '{aNewTitle.Trim()}'. ";
                    bookService.UpdateBookAuthor(aNewTitle, aNewAuthor);
                    var anOldAuthor = db.Authors.FirstOrDefault(x => x.Id == aBook.AuthorId);
                    var anNewAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aNewAuthor.Trim());
                    if (anNewAuthor == null)
                    {
                        labelCommands.Text += $"An Author by the name '{aNewAuthor.Trim()}' wasn't found, so was registered. ";
                    }
                    labelCommands.Text += $"Book '{aNewTitle.Trim()}''s Author was successfully changed from {anOldAuthor.Name.Trim()} to {aNewAuthor.Trim()}. ";
                    labelCommands.Text += $"Book '{aNewTitle.Trim()}''s Description was successfully changed from '{aBook.Description.Trim()}' to '{aNewDescription.Trim()}'.";
                    bookService.UpdateBookDescription(aNewTitle, aNewDescription);
                    if (aNewQuantity >= 0)
                    {
                        labelCommands.Text += $"Book '{aNewTitle.Trim()}''s Quantity was successfully changed from {aBook.Quantity} to {aNewQuantity}.";
                        bookService.UpdateBookQuantity(aNewTitle, aNewQuantity);
                    }
                    else
                    {
                        labelCommands.Text += $"The new Quantity {aNewQuantity} is below 0, so it wasn't changed";
                    }
                }
            }
            catch (FormatException ex) 
            { 
                labelCommands.Text = "Please enter only natural numbers"; 
            }
        }

        private void UpdateBookQuantity()
        {
            string aBookTitle = textBox1.Text;
            int aNewQuantity = 0;
            try
            {
                aNewQuantity = int.Parse(textBox2.Text);

                var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
                if (aBook != null)
                {
                    if (aNewQuantity >= 0)
                    {
                        labelCommands.Text = $"Book '{aBookTitle.Trim()}''s Quantity was successfully changed from {aBook.Quantity} to {aNewQuantity}.";
                        bookService.UpdateBookQuantity(aBookTitle, aNewQuantity);
                    }
                    else
                    {
                        labelCommands.Text = $"The new Quantity {aNewQuantity} is below 0, so it wasn't changed";
                    }
                }
                else
                {
                    labelCommands.Text = $"Book '{aBookTitle.Trim()}' wasn't found.";
                }
            }
            catch (FormatException ex) 
            { 
                labelCommands.Text = "Please enter only natural number";
            }
        }

        private void UpdateBookDescription()
        {
            string aBookTitle = textBox1.Text;
            string aNewDescription = textBox2.Text;
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            if (aBook != null)
            {
                Text = $"Book '{aBookTitle.Trim()}''s Description was successfully changed from '{aBook.Description.Trim()}' to '{aNewDescription.Trim()}'.";
                bookService.UpdateBookDescription(aBookTitle, aNewDescription);
            }
            else
            {
                labelCommands.Text = ($"Book '{aBookTitle.Trim()}' wasn't found.");
            }
        }

        private void UpdateBookAuthor()
        {
            labelCommands.Text = "";
            string aBookTitle = textBox1.Text;
            string aNewAuthor = textBox2.Text;
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            if (aBook == null)
            {
                labelCommands.Text = $"Book '{aBookTitle.Trim()}' wasn't found.";
            }
            else if (aNewAuthor == "")
            {
                labelCommands.Text = $"New Author '{aNewAuthor.Trim()}' is empty, so wan't registered.";
            }
            else
            {
                bookService.UpdateBookAuthor(aBookTitle, aNewAuthor);
                var anOldAuthor = db.Authors.FirstOrDefault(x => x.Id == aBook.AuthorId);
                var anNewAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aNewAuthor.Trim());
                if (anNewAuthor == null)
                {
                    labelCommands.Text += $"An Author by the name '{aNewAuthor.Trim()}' wasn't found, so was registered. ";
                }
                labelCommands.Text += $"Book '{aBookTitle.Trim()}''s Author was successfully changed from {anOldAuthor.Name.Trim()} to {aNewAuthor.Trim()}. ";
            }
        }

        private void UpdateBookTitle()
        {
            string anOldTitle = textBox1.Text;
            string aNewTitle = textBox2.Text;
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == anOldTitle.Trim());
            if (aBook == null)
            {
                labelCommands.Text = $"Book '{anOldTitle.Trim()}' wasn't found.";
            }
            else if (aNewTitle == "")
            {
                labelCommands.Text = $"New Title '{aNewTitle.Trim()}' is empty, so wan't registered.";
            }
            else
            {
                bookService.UpdateBookTitle(anOldTitle, aNewTitle);
                labelCommands.Text = $"Book '{anOldTitle.Trim()}' was successfully renamed to '{aNewTitle.Trim()}'.";
            }
        }

        private void DeleteBook()
        {
            string aBookTitle = textBox1.Text;
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            if (aBook != null)
            {
                bookService.DeleteBookByTitle(aBookTitle);
                labelCommands.Text = $"Book '{aBookTitle.Trim()}' was successfully removed.";

            }
            else
            {
                labelCommands.Text = $"Book '{aBookTitle.Trim()}' wasn't found.";
            }
        }

        private void RegisterNewBook()
        {
            try
            {
                labelCommands.Text = "";
                string aBookTitle = textBox1.Text;
                string aBookAuthor = textBox2.Text;
                string aBookDescription = textBox3.Text;
                int aBookQuantity = int.Parse(textBox4.Text);
                var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
                if (aBook != null)
                {
                    labelCommands.Text = $"Book by the title of '{aBookTitle.Trim()}' is already registered.";
                }
                else if (aBookTitle == "")
                {
                    labelCommands.Text = $"Title '{aBookTitle.Trim()}' is empty, so wan't registered.";
                }
                else if (aBookAuthor == "")
                {
                    labelCommands.Text = $"Author'{aBookAuthor.Trim()}' is empty, so wan't registered.";
                }
                else
                {
                    if (aBookQuantity < 0)
                    {
                        labelCommands.Text += $"Book Quantity: {aBookQuantity} wasn't above 0, so it was registered as 0. ";
                    }
                    var anAuthor = db.Authors.FirstOrDefault(x => x.Name.Trim() == aBookAuthor.Trim());
                    if (anAuthor == null)
                    {
                        labelCommands.Text += $"An Author by the name '{aBookAuthor.Trim()}' wasn't found, so was registered. ";
                    }
                    bookService.RegisterNewBook(aBookTitle, aBookAuthor, aBookDescription, aBookQuantity);
                    labelCommands.Text += $"Book '{aBookTitle.Trim()}' was successfully registered.";
                }
                labelCommands.Text += $"Book '{aBookTitle.Trim()}' was successfully registered.";
            }
            catch (FormatException ex)
            {
                labelCommands.Text = "Please enter only natural number";
            }

        }

        private void GetAllLogsFromLibraryCardByName()
        {
            string aLibraryCardName = textBox1.Text;
            var allLogs = logService.GetAllLogsFromLibraryCardByName(aLibraryCardName);
            if (allLogs != null)
            {
                EnableDateGridView1();
                dataGridView1.DataSource = allLogs;
            }
            else
            {
                labelCommands.Text= $"Logs for '{aLibraryCardName}' weren't found.";
            }
        }

        private void GetAllLogsForBookByTitle()
        {
            string aBookTitle = textBox1.Text;
            var allLogs = logService.GetAllLogsForBookByTitle(aBookTitle);
            if (allLogs != null)
            {
                EnableDateGridView1();
                dataGridView1.DataSource = allLogs;
            }
            else
            {
                labelCommands.Text = $"Logs for '{aBookTitle}' weren't found.";
            }
        }

        private void GetAllLogs()
        {
            EnableDateGridView1();
            dataGridView1.DataSource = logService.GetAllLogs();
        }

        private void ReturnBook()
        {
            string aBookTitle = textBox1.Text;
            string aLibraryCardName = textBox2.Text;
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aLibraryCardName.Trim());
            if (aBook == null && aLibraryCard == null)
            {
                labelCommands.Text = $"Both Book '{aBookTitle.Trim()}' and LibraryCard for '{aLibraryCardName.Trim()}' weren't found.";
            }
            else if (aBook == null)
            {
                labelCommands.Text = $"Book '{aBookTitle.Trim()}' wasn't found.";
            }
            else if (aLibraryCard == null)
            {
                labelCommands.Text = $"LibraryCard for '{aLibraryCardName.Trim()}' wasn't found.";
            }
            else
            {
                var aLog = db.Logs.FirstOrDefault(x => x.BookId == aBook.Id && x.LibraryCardId == aLibraryCard.Id && x.IsReturned == false);
                if (aLog == null)
                {
                    labelCommands.Text = $"An unreturned log with this Book '{aBookTitle.Trim()}' and taken by '{aLibraryCardName.Trim()}' wasn't found.";
                }
                else
                {
                    logService.ReturnBook(aBookTitle,aLibraryCardName);
                    labelCommands.Text = $"'{aLibraryCardName.Trim()}' has returned a copy of '{aBookTitle.Trim()}'.";
                }
            }
        }

        private void TakeBook()
        {
            string aBookTitle = textBox1.Text;
            string aLibraryCardName = textBox2.Text;
            var aBook = db.Books.FirstOrDefault(x => x.Title.Trim() == aBookTitle.Trim());
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aLibraryCardName.Trim());
            if (aBook == null && aLibraryCard == null)
            {
                labelCommands.Text = $"Both Book '{aBookTitle.Trim()}' and LibraryCard for '{aLibraryCardName.Trim()}' weren't found.";
            }
            else if (aBook == null)
            {
                labelCommands.Text = $"Book '{aBookTitle.Trim()}' wasn't found.";
            }
            else if (aLibraryCard == null)
            {
                labelCommands.Text = $"LibraryCard for '{aLibraryCardName.Trim()}' wasn't found.";
            }
            else
            {
                if (aBook.Quantity > 0)
                {
                    logService.TakeBook(aBookTitle,aLibraryCardName);
                    labelCommands.Text = $"'{aLibraryCardName.Trim()}' has successfully taken a copy of '{aBookTitle.Trim()}'.";
                }
                else
                {
                    labelCommands.Text = $"There aren't any available copies of '{aBookTitle.Trim()}'.";
                }
            }
        }

        private void GetLibraryCards()
        {
            EnableDateGridView1();
            dataGridView1.DataSource=libraryCardService.GetAllLibraryCards();
        }
        private void UpdateLibraryCardName()
        {
            string aOldName = textBox1.Text;
            string aNewName = textBox2.Text;
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aOldName.Trim());
            if (aLibraryCard == null)
            {
                labelCommands.Text = $"LibraryCard for '{aOldName.Trim()}' wasn't found.";
            }
            else if (aNewName == "")
            {
                labelCommands.Text = $"New Name '{aNewName.Trim()}' is empty, so wan't registered.";
            }
            else
            {
                libraryCardService.UpdateLibraryCardName(aOldName,aNewName);
                labelCommands.Text = $"LibraryCard for '{aOldName.Trim()}' was successfully renamed to '{aNewName.Trim()}'.";
            }
            
        }

        private void DeleteLibraryCard()
        {
            string aName = textBox1.Text;
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aName.Trim());
            if (aLibraryCard != null)
            {
                libraryCardService.DeleteLibraryCardByName(aName);
                labelCommands.Text = $"LibraryCard for '{aName.Trim()}' was successfully removed, alongside it's logs.";
            }
            else
            {
                labelCommands.Text = $"LibraryCard for '{aName.Trim()}' wasn't found.";
            }
            
        }
        private void RegisterNewLibraryCard()
        {
            string aName = textBox1.Text;
            var aLibraryCard = db.LibraryCards.FirstOrDefault(x => x.Name.Trim() == aName.Trim());
            if (aLibraryCard != null)
            {
                labelCommands.Text = $"LibraryCard for '{aName.Trim()}' is already registered.";
            }
            else if (aName == "")
            {
                labelCommands.Text = $"Name '{aName.Trim()}' is empty, so wan't registered.";
            }
            else 
            {
                libraryCardService.RegisterNewLibraryCard(aName);
                labelCommands.Text = $"LibraryCard for '{aName.Trim()}' was successfully registered.";
            }
            
        }
    }
}
