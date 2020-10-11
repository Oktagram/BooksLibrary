using System;
using BooksLibrary.Domain.Authors;
using BooksLibrary.Domain.Books.Enums;

namespace BooksLibrary.Domain.Books.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public BookGenre Genre { get; set; }

        public BookStatus Status { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishedYear { get; set; }

        public BookOrder BookOrder { get; set; }
    }
}
