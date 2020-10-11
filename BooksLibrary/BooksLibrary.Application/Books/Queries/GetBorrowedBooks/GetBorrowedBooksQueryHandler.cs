using System;
using BooksLibrary.Application.Books.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Contracts;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Books.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Books.Queries.GetBorrowedBooks
{
    public class GetBorrowedBooksQueryHandler : IRequestHandler<GetBorrowedBooksQuery, Dictionary<string, List<BorrowedBookResponseDto>>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetBorrowedBooksQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, List<BorrowedBookResponseDto>>> Handle(GetBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.BorrowedBooks
                .Include(b => b.Book)
                .AsQueryable();

            query = Search(request, query);
            query = OrderBy(request, query);

            var list = await query
                .ProjectToType<BorrowedBookResponseDto>()
                .ToListAsync(cancellationToken);

            var result = GroupBy(list, request.GroupBy);

            return result;
        }

        private IQueryable<BorrowedBook> Search(GetBorrowedBooksQuery request, IQueryable<BorrowedBook> query)
        {
            if (!string.IsNullOrEmpty(request.ReaderName))
                query = query.Where(b => b.Reader.Name.Contains(request.ReaderName));

            if (!string.IsNullOrEmpty(request.LibrarianName))
                query = query.Where(b => b.Librarian.Name.Contains(request.LibrarianName));

            if (!string.IsNullOrEmpty(request.Title))
                query = query.Where(b => b.Book.Title.Contains(request.Title));

            return query;
        }

        private static IQueryable<BorrowedBook> OrderBy(
            GetBorrowedBooksQuery request, IQueryable<BorrowedBook> query)
        {
            switch (request.OrderBy)
            {
                case BorrowedBookFilter.Reader:
                    return request.IsDesk
                        ? query.OrderByDescending(b => b.Reader.Name)
                        : query.OrderBy(b => b.Reader.Name);

                case BorrowedBookFilter.Librarian:
                    return request.IsDesk
                        ? query.OrderByDescending(b => b.Librarian.Name)
                        : query.OrderBy(b => b.Librarian.Name);

                case null:
                    return query;

                default:
                    throw new ArgumentOutOfRangeException(nameof(request.OrderBy), request.OrderBy, null);
            }
        }

        private Dictionary<string, List<BorrowedBookResponseDto>> GroupBy(
            List<BorrowedBookResponseDto> source, BorrowedBookFilter? groupBy)
        {
            if (!groupBy.HasValue)
                return new Dictionary<string, List<BorrowedBookResponseDto>>
                {
                    {string.Empty, source}
                };

            var groupByFunc = GetGroupByFunc();

            return source
                .GroupBy(groupByFunc)
                .ToDictionary(g => g.Key, g => g.ToList());

            Func<BorrowedBookResponseDto, string> GetGroupByFunc()
            {
                switch (groupBy.Value)
                {
                    case BorrowedBookFilter.Reader:
                        return book => book.ReaderName;

                    case BorrowedBookFilter.Librarian:
                        return book => book.LibrarianName;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
