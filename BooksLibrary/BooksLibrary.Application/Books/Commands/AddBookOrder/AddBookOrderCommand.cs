using System;
using MediatR;

namespace BooksLibrary.Application.Books.Commands.AddBookOrder
{
    public class AddBookOrderCommand : IRequest<int>
    {
        public string AuthorName { get; set; }
        public int BookGenreId { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishedYear { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int ReaderId { get; set; }
    }
}
