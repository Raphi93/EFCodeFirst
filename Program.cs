using EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

internal class Program
{
    private static void Main(string[] args)
    {
        Insert();
        Select();
    }
    private static void Select()
    {
        var contextOptions = new DbContextOptionsBuilder<BookContext>()
            .UseSqlServer(@"Server=.\;Database=EFCoreCodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

        using (var context = new BookContext(contextOptions))
        {
            foreach(var author in context.Author.ToList())
            {
                Console.WriteLine($"{author.AuthorId}, {author.FirstName} {author.LastName}");
                foreach (var book in context.Books)
                {
                    Console.WriteLine($"{book.BookId}  {book.Title}");
                }
                
            }
        }
    }

    private static void Insert()
    {
        var contextOptions = new DbContextOptionsBuilder<BookContext>()
            .UseSqlServer(@"Server=.\;Database=EFCoreCodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

        using (var context = new BookContext(contextOptions))
        {
            if (!context.Author.Where(w => w.FirstName == "William" && w.LastName == "Hallo")
                .Any())
            {
                var author = new Author
                {
                    FirstName = "William",
                    LastName = "Hallo",
                    Books = new List<Book>
                {
                    new Book {Title = "Hallo"},
                    new Book {Title = "njoo"},
                    new Book {Title = "hahahah"}
                }
                };
                context.Add(author);
                context.SaveChanges();
            }
        }
    }
}