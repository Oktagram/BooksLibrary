using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.Domain.Entities
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public int LibrarianId { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
