using BooksLibrary.Application.Books.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Books.Queries.GetBorrowedBooks
{
    public class GetBorrowedBooksQueryHandler : IRequestHandler<GetBorrowedBooksQuery, List<BookResponseDto>>
    {
        public Task<List<BookResponseDto>> Handle(GetBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
