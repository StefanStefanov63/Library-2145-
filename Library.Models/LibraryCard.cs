using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class LibraryCard
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Log> Logs { get; set; } = new HashSet<Log>();
        
    }
}
