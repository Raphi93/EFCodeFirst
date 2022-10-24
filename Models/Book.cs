using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public partial class Book
    {
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }

    }
}