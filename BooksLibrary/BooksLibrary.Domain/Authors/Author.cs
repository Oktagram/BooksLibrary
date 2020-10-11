using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BooksLibrary.Domain.Books.Entities;

namespace BooksLibrary.Domain.Authors
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
