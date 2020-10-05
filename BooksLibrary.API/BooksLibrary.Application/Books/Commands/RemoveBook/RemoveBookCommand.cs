using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.Application.Books.Commands.RemoveBook
{
    public class RemoveBookCommand
    {
        public RemoveBookCommand(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; }
    }
}
