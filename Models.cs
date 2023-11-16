using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manytomanny
{


    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; } //kompozicija i lentele books
    }
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<BookCategory> BookCategories { get; set; }
        public Author Author { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }


    public class BookCategory //many to many jungiamoji lentelė
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public Book Book { get; set; }
        public Category Category { get; set; }
    }



}
