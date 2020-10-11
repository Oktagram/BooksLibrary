using System;
using System.ComponentModel.DataAnnotations;
using BooksLibrary.Domain.Users;

namespace BooksLibrary.Domain.Books.Entities
{
    public class BorrowedBook
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; }

        public int LibrarianId { get; set; }
        public Librarian Librarian { get; set; }

        public DateTime BorrowDate { get; set; }
    }
}
