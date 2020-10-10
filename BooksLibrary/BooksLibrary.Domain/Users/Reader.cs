using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Domain.Entities
{
    public class Reader
    {
        public Reader()
        {
            BorrowedBooks = new List<BorrowedBook>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MemberSince { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<BorrowedBook> BorrowedBooks { get; set; }
    }
}
