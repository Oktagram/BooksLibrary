﻿using System;
using System.Collections.Generic;
using BooksLibrary.Domain.Books.Entities;

namespace BooksLibrary.Domain.Users
{
    public class Reader
    {
        public Reader()
        {
            BorrowedBooks = new List<BorrowedBook>();
            BookOrders = new List<BookOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MemberSince { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<BorrowedBook> BorrowedBooks { get; set; }
        public List<BookOrder> BookOrders { get; set; }
    }
}
