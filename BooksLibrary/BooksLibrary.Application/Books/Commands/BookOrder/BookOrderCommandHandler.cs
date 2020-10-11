using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Books.Commands.BookOrder
{
    public class BookOrderCommandHandler : IRequestHandler<BookOrderCommand, int>
    {
        public Task<int> Handle(BookOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
