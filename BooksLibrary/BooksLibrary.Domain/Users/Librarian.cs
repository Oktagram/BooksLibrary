using System.Collections.Generic;
using BooksLibrary.Domain.Books.Entities;

namespace BooksLibrary.Domain.Users
{
    public class Librarian
    {
        public Librarian()
        {
            LentBooks = new List<BorrowedBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<BorrowedBook> LentBooks { get; set; }
    }
}
