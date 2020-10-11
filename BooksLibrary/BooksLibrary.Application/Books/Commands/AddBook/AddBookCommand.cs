using System;
using MediatR;

namespace BooksLibrary.Application.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest
    {
        public int AuthorId { get; set; }
        public int BookGenreId { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime Year { get; set; }
    }
}
