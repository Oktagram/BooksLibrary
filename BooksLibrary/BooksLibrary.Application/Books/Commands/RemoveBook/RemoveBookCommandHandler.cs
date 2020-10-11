using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Application.Exceptions;

namespace BooksLibrary.Application.Books.Commands.RemoveBook
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public RemoveBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.FindAsync(request.BookId);

            if (book == null)
                throw new NotFoundException($"Book with id {request.BookId} not found");

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
