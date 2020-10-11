using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Books.Models;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;
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

        public async Task<Dictionary<string, List<BookResponseDto>>> Handle(GetBooksQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.Books.AsQueryable();

            query = Search(request, query);
            query = OrderBy(query, request.OrderBy, request.IsDesc);

            var list = await query
                .ProjectToType<BookResponseDto>()
                .ToListAsync(cancellationToken);

            var result = GroupBy(list, request.GroupBy);

            return result;
        }

        private IQueryable<Book> Search(GetBooksQuery request, IQueryable<Book> books)
        {
            if (!string.IsNullOrEmpty(request.AuthorName))
                books = books.Where(b => b.Author.Name.Contains(request.AuthorName));

            if (request.BookGenreId.HasValue)
                books = books.Where(b => b.GenreId == request.BookGenreId);

            if (!string.IsNullOrEmpty(request.Title))
                books = books.Where(b => b.Title.Contains(request.Title));

            if (request.PublishedYear.HasValue)
                books = books.Where(b => b.PublishedYear == request.PublishedYear);

            if (request.BookStatus.HasValue)
                books = books.Where(b => b.Status == request.BookStatus);

            return books;
        }

        private IQueryable<Book> OrderBy(
            IQueryable<Book> source,
            BookFilter? orderBy,
            bool isDesc)
        {
            switch (orderBy)
            {
                case BookFilter.Author:
                    return isDesc
                        ? source.OrderByDescending(b => b.Author.Name)
                        : source.OrderBy(b => b.Author.Name);

                case BookFilter.Genre:
                    return isDesc
                        ? source.OrderByDescending(b => b.Genre.Name)
                        : source.OrderBy(b => b.Genre.Name);

                case BookFilter.Year:
                    return isDesc
                        ? source.OrderByDescending(b => b.PublishedYear)
                        : source.OrderBy(b => b.PublishedYear);

                case null:
                    return source;

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBy), orderBy, null);
            }
        }

        private Dictionary<string, List<BookResponseDto>> GroupBy(
            List<BookResponseDto> source, BookFilter? groupBy)
        {
            if (!groupBy.HasValue)
            {
                return new Dictionary<string, List<BookResponseDto>>
                {
                    {string.Empty, source}
                };
            }

            var groupByFunc = GetGroupByFunc();

            return source
                .GroupBy(groupByFunc)
                .ToDictionary(g => g.Key, g => g.ToList());

            Func<BookResponseDto, string> GetGroupByFunc()
            {
                switch (groupBy.Value)
                {
                    case BookFilter.Author:
                        return book => book.AuthorName;

                    case BookFilter.Genre:
                        return book => book.GenreId.ToString();

                    case BookFilter.Year:
                        return book => book.PublishedYear.ToString("dd/MM/yyyy");

                    default:
                        throw new ArgumentOutOfRangeException(nameof(groupBy), groupBy, null);
                }
            }
        }
    }
}
