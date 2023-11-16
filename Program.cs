using Microsoft.EntityFrameworkCore;

namespace manytomanny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Many to Many!");
            var dbContext = new BookContext(new DbContextOptionsBuilder<BookContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NETUA2_books;Trusted_Connection=True;")
                .Options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var tolkien = new Author { LastName = "Tolkien" };
            var adams = new Author { LastName = "Adams" };
            var herbert = new Author { LastName = "Herbert" };
            var card = new Author { LastName = "Card" };

            dbContext.Authors.AddRange(tolkien, adams, herbert, card);
            dbContext.SaveChanges();

            var hobbit = new Book { Title = "The Hobbit", Year = 1937, Author = tolkien };
            var lordOfTheRings = new Book { Title = "The Lord of the Rings", Year = 1954, Author = tolkien };
            var silmarillion = new Book { Title = "The Silmarillion", Year = 1977, Author = tolkien }; //Silmariljonas, Dþonas Ronaldas Reuelis Tolkinas
            var hitchhikersGuide = new Book { Title = "The Hitchhiker's Guide to the Galaxy", Year = 1979, Author = adams };
            var dune = new Book { Title = "Dune", Year = 1965, Author = herbert };
            var endersGame = new Book { Title = "Ender's Game", Year = 1985, Author = card };

            dbContext.Books.AddRange(hobbit, lordOfTheRings, silmarillion, hitchhikersGuide, dune, endersGame);
            dbContext.SaveChanges();

            var catAdventure = new Category { CategoryName = "Adventure" };
            var catScience = new Category { CategoryName = "Science Fiction" };

            dbContext.Categories.AddRange(catAdventure, catScience);
            dbContext.SaveChanges();

            dbContext.BookCategories.Add(new BookCategory { Category = catAdventure, Book = hobbit });
            dbContext.BookCategories.Add(new BookCategory { Category = catAdventure, Book = lordOfTheRings });
            dbContext.BookCategories.Add(new BookCategory { Category = catAdventure, Book = silmarillion });

            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = hitchhikersGuide });
            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = dune });
            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = endersGame });
            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = hobbit });

            dbContext.SaveChanges();


        }
    }
}