using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.Application.Books.Commands.BookOrder
{
    public class BookOrderCommand
    {
        public int AuthorId { get; set; }
        public int BookGenreId { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime Year { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int ReaderId { get; set; }
    }
}
