using System.Collections.Generic;

namespace BooksLibrary.Domain.Books.Entities
{
    public class BookGenre
    {
        public BookGenre()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public List<Book> Books { get; set; }
    }
}
