using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Books.Commands.RemoveBook
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand>
    {
        public Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
