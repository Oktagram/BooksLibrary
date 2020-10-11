using BooksLibrary.Application.Books.Models;
using BooksLibrary.Domain.Books.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace BooksLibrary.Application.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<List<BookResponseDto>>
    {
        public string AuthorName { get; set; }
        public int? BookGenreId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishedYear { get; set; }

        public BookFilter? OrderBy { get; set; }
        public bool IsDesc { get; set; }

        public BookFilter? GroupBy { get; set; }
    }
}
