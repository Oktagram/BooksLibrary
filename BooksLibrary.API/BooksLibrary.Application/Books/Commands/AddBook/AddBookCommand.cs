using System;

namespace BooksLibrary.Application.Books.Commands
{
    public class AddBookCommand
    {
        public int AuthorId { get; set; }
        public int BookGenreId { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime Year { get; set; }
    }
}
