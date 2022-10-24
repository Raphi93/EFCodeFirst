using EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    private static void Select()
    {
        var contextOptions = new DbContextOptionsBuilder<BookContext>()
            .UseSqlServer(@"Server=.\;Database=EFCoreFirst;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

        using (var context = BookContextModelSnapshot(contextOptions))
        {
            Console.WriteLine("Kategorie");
            foreach (var k in context)
            {
                Console.WriteLine($"{k.KategorieId}, {k.Kategorie1}");
            }
            var q = context.Kategories.Where(e => e.Kategorie1 == "Bikes").FirstOrDefault();
            if (q != null)
            {
                Console.WriteLine($"{q.KategorieId}, {q.Kategorie1}");
                foreach (var u in q.Unterkategories)
                {
                    Console.WriteLine($"{u.Unterkategorie1}");
                }
            }
        }
    }

    private static void Insert()
    {
        var contextOptions = new DbContextOptionsBuilder<efzLagerContext>()
            .UseSqlServer(@"Server=.\;Database=efzLager;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

        using (var context = new efzLagerContext(contextOptions))
        {
            Kategorie k = new Kategorie()
            {
                Kategorie1 = "Auto"
            };
            context.Add(k);
            context.SaveChanges();
        }
    }
}