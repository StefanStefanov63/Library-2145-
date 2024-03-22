using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public bool IsReturned { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public int LibraryCardId { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; } = new HashSet<LibraryCard>();
    }
}
