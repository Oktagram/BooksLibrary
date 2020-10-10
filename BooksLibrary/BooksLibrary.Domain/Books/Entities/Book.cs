using BooksLibrary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookGenreId { get; set; }
        public int BookStatusId { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime Year { get; set; }
    }
}
