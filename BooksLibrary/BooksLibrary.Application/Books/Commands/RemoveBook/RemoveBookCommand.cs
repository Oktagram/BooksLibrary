using MediatR;

namespace BooksLibrary.Application.Books.Commands.RemoveBook
{
    public class RemoveBookCommand : IRequest
    {
        public RemoveBookCommand(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; }
    }
}
