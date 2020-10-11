using System.Collections.Generic;
using BooksLibrary.Domain.Books.Entities;

namespace BooksLibrary.Domain.Authors
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
