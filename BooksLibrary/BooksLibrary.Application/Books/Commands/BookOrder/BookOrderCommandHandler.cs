using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Books.Commands.BookOrder
{
    public class BookOrderCommandHandler : IRequestHandler<BookOrderCommand>
    {
        public Task<Unit> Handle(BookOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
