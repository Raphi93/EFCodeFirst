using Microsoft.EntityFrameworkCore;
using EFCoreCodeFirst.Models;

namespace EFCoreCodeFirst.Models
{
    public partial class BookContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog=EFCoreCodeFirst;Integrated Security=True");
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookContext()
        {
        }
   
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

    }
}