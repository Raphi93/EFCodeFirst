using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public partial class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public ICollection<Book> Books { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}