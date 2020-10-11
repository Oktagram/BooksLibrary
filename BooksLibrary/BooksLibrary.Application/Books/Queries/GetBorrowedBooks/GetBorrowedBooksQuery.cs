using BooksLibrary.Application.Books.Models;
using BooksLibrary.Domain.Books.Enums;
using MediatR;
using System.Collections.Generic;

namespace BooksLibrary.Application.Books.Queries.GetBorrowedBooks
{
    public class GetBorrowedBooksQuery : IRequest<Dictionary<string, List<BorrowedBookResponseDto>>>
    {
        public string ReaderName { get; set; }
        public string LibrarianName { get; set; }
        public string Title { get; set; }

        public BorrowedBookFilter? OrderBy { get; set; }
        public bool IsDesk { get; set; }

        public BorrowedBookFilter? GroupBy { get; set; }
    }
}
