using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Books.Notifications.BookAdded;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;
using Mapster;

namespace BooksLibrary.Application.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMediator _mediator;

        public AddBookCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.Adapt<Book>();

            book.Status = BookStatus.InStock;

            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new BookAddedNotification
            {
                BookId = book.Id
            }, cancellationToken);

            return book.Id;
        }
    }
}
