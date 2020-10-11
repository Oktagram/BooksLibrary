using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Authors;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;
using Mapster;
using MediatR;

namespace BooksLibrary.Application.Books.Commands.AddBookOrder
{
    public class AddBookOrderCommandHandler : IRequestHandler<AddBookOrderCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddBookOrderCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(AddBookOrderCommand request, CancellationToken cancellationToken)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Name == request.AuthorName) ?? new Author { Name = request.AuthorName };

            var book = request.Adapt<Book>();

            book.BookOrder = new BookOrder
            {
                ExpectedDate = request.ExpectedDate.Date,
                ReaderId = request.ReaderId
            };

            book.Author = author;
            book.Status = BookStatus.Ordered;

            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return book.BookOrder.Id;
        }
    }
}
