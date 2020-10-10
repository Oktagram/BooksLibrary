using BooksLibrary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BooksLibrary.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public BookGenre Genre { get; set; }

        public int Status { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishedYear { get; set; }

        public BookOrder BookOrder { get; set; }
    }
}
