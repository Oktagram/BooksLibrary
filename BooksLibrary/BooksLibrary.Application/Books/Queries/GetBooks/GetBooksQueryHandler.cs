using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Books.Models;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Application.Books.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, Dictionary<string, List<BookResponseDto>>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetBooksQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, List<BookResponseDto>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Books.AsQueryable();

            query = Search(request, query);

            if (request.OrderBy.HasValue)
                query = query.OrderBy(request.OrderBy.Value, request.IsDesc);

            var list = await query
                .ProjectToType<BookResponseDto>()
                .ToListAsync(cancellationToken);

            var result = list.GroupBy(request.GroupBy);

            return result;
        }

        private IQueryable<Book> Search(GetBooksQuery request, IQueryable<Book> books)
        {
            if (!string.IsNullOrEmpty(request.AuthorName))
                books = books.Where(b => b.Author.Name == request.AuthorName);

            if (request.BookGenreId.HasValue)
                books = books.Where(b => b.GenreId == request.BookGenreId);

            if (!string.IsNullOrEmpty(request.Title))
                books = books.Where(b => b.Title == request.Title);

            if (request.PublishedYear.HasValue)
                books = books.Where(b => b.PublishedYear == request.PublishedYear);

            if (request.BookStatus.HasValue)
                books = books.Where(b => b.Status == request.BookStatus);

            return books;
        }
    }
}
