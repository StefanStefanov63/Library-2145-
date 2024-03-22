using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.IO;
using Library.Models;
using System.Net;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public LibraryContext() {}
        public LibraryContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-K0PGIEU\\SQLEXPRESS;Database=Library;Integrated Security=true;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<LibraryCard>()
                .HasMany(x => x.Logs)
                .WithOne(x => x.LibraryCard)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LibraryCard>().HasData(
                new LibraryCard { Id = 1, Name = "Leon Zabini" },
                new LibraryCard { Id = 2, Name = "Bjorn Tempestson" },
                new LibraryCard { Id = 3, Name = "Count Haesteinn of Montaigu" },
                new LibraryCard { Id = 4, Name = "Siting Bull" },
                new LibraryCard { Id = 5, Name = "Liu Fang" });
            modelBuilder.Entity<Log>().HasData(
                new Log { Id = 1, IsReturned = false, BookId = 3, LibraryCardId = 1 },
                new Log { Id = 2, IsReturned = false, BookId = 7, LibraryCardId = 2 },
                new Log { Id = 3, IsReturned = true, BookId = 2, LibraryCardId = 3 },
                new Log { Id = 4, IsReturned = false, BookId = 2, LibraryCardId = 1 },
                new Log { Id = 5, IsReturned = false, BookId = 3, LibraryCardId = 3 },
                new Log { Id = 6, IsReturned = true, BookId = 6, LibraryCardId = 5 },
                new Log { Id = 7, IsReturned = false, BookId = 8, LibraryCardId = 2 },
                new Log { Id = 8, IsReturned = true, BookId = 9, LibraryCardId = 4 },
                new Log { Id = 9, IsReturned = true, BookId = 10, LibraryCardId = 3 },
                new Log { Id = 10, IsReturned = false, BookId = 4, LibraryCardId = 2 });
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Cultist of Cerebon", AuthorId = 1, Quantity = 1},
                new Book { Id = 2, Title = "A Nerubian's Journey", AuthorId = 1, Quantity = 3 },
                new Book { Id = 3, Title = "Jackal Among Snakes", AuthorId = 2, Quantity = 6 },
                new Book { Id = 4, Title = "A Rational Zombie", AuthorId = 3, Description = "An existentialist zombie seeks the meaning of life one mouthful at a time.", Quantity = 1 },
                new Book { Id = 5, Title = "Master of the System", AuthorId = 3, Quantity = 1 },
                new Book { Id = 6, Title = "Zenith of Sorcery", AuthorId = 4, Description = "A new fantasy story from the author of Mother of Learning.\r\n\r\nAfter years of exile, Marcus is coming back home. A powerful mage with few equals, Marcus lives in a world full of monsters and powerful adepts, many of which have bad histories with him. But he has not come back to pursue vengeance or start a fight. All Marcus wants to do is reconnect with old friends, build himself a house, and maybe train a successor or two.\r\n\r\nAlas, the world didn’t stop just because Marcus went into exile, and not everyone is content to let go of old grievances. Strange things are happening in the world at large, too, hinting at a looming disaster of unknown nature. Still, where there is a will, there is a way.\r\n\r\nIf nothing else, Marcus has a lot of magical power to throw at problems.", Quantity = 10 },
                new Book { Id = 7, Title = "Mother of Learning", AuthorId = 4, Quantity = 2 },
                new Book { Id = 8, Title = "Paranoid Mage", AuthorId = 5, Description = "Callum had seen things all his life.  There are monsters and beasts living among people, but he learned very early not to admit such things, not if he didn’t want people to think him crazy.\r\n\r\nIt turns out that the supernatural is real, but at thirty Callum has no desire to be part of that secret.  Not that he has a choice when it turns out he is a mage, albeit one that hasn’t cast any spells in all his life.  There are requirements, duties, and education that the powers that be insist he be subject to.\r\n\r\nTo hell with that.", Quantity = 4 },
                new Book { Id = 9, Title = "Chasing Sunlight", AuthorId = 5, Description = "In a world of lightless skies and endless secrets, humanity is a vigil of light against the eternal darkness.  Under the imprimatur of the Illuminated King and the nefarious endorsement of the Reflected Council, a veteran explorer assembles an expedition to the far east.  A place that no sane and god-fearing man would ever go.\r\n\r\nJonathan Heights will, and must, for he claims to have seen sunlight.  A laughable myth and fairy tale, but he will not be stopped on his journey to find it again.\r\n\r\nWonders and horrors both lie between the human lands and his ultimate goal; things long-forgotten and long-dead, that which could not be recorded on any map.  They are temptation and terror to the wise and foolish alike, but not to Jonathan. His purpose is clear, and he has but one goal, yet the truth is shrouded and motives remain uncertain among the agents of both crown and underworld as they join Jonathan aboard the airship Endeavor to sail the strange and exotic lands out there in the darkness.\r\n\r\n", Quantity = 8 },
                new Book { Id = 10, Title = "An Unborn Hero", AuthorId = 6, Quantity = 3 },
                new Book { Id = 11, Title = "Super Minion", AuthorId = 7, Description = "Fortress City has Super Villains, who have evil lairs, and in them they make super weapons. But when a bioweapon is granted super powers of its own, will Fortress City be able to handle the Super Minion?", Quantity = 7 },
                new Book { Id = 12, Title = "Human Altered", AuthorId = 8, Quantity = 6 },
                new Book { Id = 13, Title = "The Legendary Mechanic", AuthorId = 9, Quantity = 11 },
                new Book { Id = 14, Title = "The Godking's Legacy", AuthorId = 3, Quantity = 5 },
                new Book { Id = 15, Title = "A Lonely Dungeon", AuthorId = 6, Description = "When a new dungeon is born, it wants nothing more than to have the most vicious monsters, the most cunning traps and the most shiny of loot. There is only one problem, but it's a rather big one; it finished its first floor years ago, but it still hasn't been visited by any adventurers! In order to find someone or something to explore its floors, or perhaps just to find someone to talk to, this dungeon will have to go way off script. But it soon discovers that going off script brings problems of its own, and that adventurers are not the only thing this world is missing.", Quantity = 9 },
                new Book { Id = 16, Title = "Dear Spellbook", AuthorId = 10, Description = "Hello stranger, my name is Tal, and I’m not an adventurer—those people are crazy. I’m just a sorcerer who is masquerading as a wizard. Oh, and I’m searching for answers about my parents’ mysterious deaths. Also monsters and other foes seem to show up wherever I go.\r\n\r\n…All right, I see it.\r\n\r\nMy new traveling companions are seasoned adventurers and are teaching me their ways—or at least they were before something happened to Time.\r\n\r\nThe same day is repeating itself over and over, and I’m the only one aware of the resets. If I ever want to get past this day—and the horrific hangover it always starts with—I’ll need to find a way out by myself.\r\n\r\nIt turns out there are mysteries aplenty to unravel in this remote forest town of Crossroads, where I’m living the same day over and over. But my most vital resource might already be in my possession. My previously useless Spellbook is starting to exhibit some very strange abilities, and they could be just what I need in my quest to escape this temporal prison.\r\n\r\nThis is my story. My diary of sorts. Don’t judge too harshly, I had a rough day.", Quantity = 8 },
                new Book { Id = 17, Title = "An Unwilling Monster", AuthorId = 1, Quantity = 1 },
                new Book { Id = 18, Title = "The Gemstone Prince", AuthorId = 3, Quantity = 2 },
                new Book { Id = 19, Title = "A Sect Elder's Journey", AuthorId = 1, Quantity = 3 },
                new Book { Id = 20, Title = "Primal Wizardry", AuthorId = 10, Quantity = 10 });
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Fizzicks" },
                new Author { Id = 2, Name = "Nemorosus" },
                new Author { Id = 3, Name = "Virlyce" },
                new Author { Id = 4, Name = "nobody103" },
                new Author { Id = 5, Name = "InadvisablyCompelled" },
                new Author { Id = 6, Name = "cathfach" },
                new Author { Id = 7, Name = "Gogglesbear" },
                new Author { Id = 8, Name = "Yousureimnotarobot" },
                new Author { Id = 9, Name = "Qi Peijia" },
                new Author { Id = 10, Name = "TK523" });
        }
    }
}
