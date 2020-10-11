using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;
using Mapster;

namespace BooksLibrary.Application.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddBookCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.Adapt<Book>();

            book.Status = BookStatus.InStock;

            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
