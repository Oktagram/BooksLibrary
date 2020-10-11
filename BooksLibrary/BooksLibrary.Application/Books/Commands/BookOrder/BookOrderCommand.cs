using MediatR;
using System;

namespace BooksLibrary.Application.Books.Commands.BookOrder
{
    public class BookOrderCommand : IRequest<int>
    {
        public int AuthorId { get; set; }
        public int BookGenreId { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishedYear { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int ReaderId { get; set; }
    }
}
