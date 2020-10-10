using BooksLibrary.Domain.Books.Enums;
using System;

namespace BooksLibrary.Application.Books.Queries.GetBooks
{
    public class GetBooksQuery
    {
        public int? AuthorId { get; set; }
        public int? BookGenreId { get; set; }
        public string Title { get; set; }
        public DateTime? Year { get; set; }

        public BookFilter? OrderBy { get; set; }
        public bool IsDesc { get; set; }

        public BookFilter? GroupBy { get; set; }
    }
}
