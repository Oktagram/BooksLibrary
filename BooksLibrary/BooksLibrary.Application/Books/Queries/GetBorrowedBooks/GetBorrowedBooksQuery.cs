using BooksLibrary.Domain.Books.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.Application.Books.Queries.GetBorrowedBooks
{
    public class GetBorrowedBooksQuery
    {
        public string Reader { get; set; }
        public string Librarian { get; set; }
        public string Title { get; set; }

        public BorrowedBookFilter? OrderBy { get; set; }
        public bool IsDesk { get; set; }

        public BorrowedBookFilter? GroupBy { get; set; }
    }
}
