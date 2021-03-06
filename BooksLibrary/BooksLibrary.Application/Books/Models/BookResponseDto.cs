﻿using System;
using BooksLibrary.Domain.Books.Enums;

namespace BooksLibrary.Application.Books.Models
{
    public class BookResponseDto
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public BookStatus Status { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishedYear { get; set; }

        public DateTime? ExpectedDate { get; set; }
    }
}
