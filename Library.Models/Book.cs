﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}
