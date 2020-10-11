using System;

namespace BooksLibrary.Application.Books.Models
{
    public class BorrowedBookResponseDto
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public string Title { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishedYear { get; set; }

        public string ReaderName { get; set; }
        public string LibrarianName { get; set; }
    }
}
