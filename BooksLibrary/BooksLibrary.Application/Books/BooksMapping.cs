using BooksLibrary.Application.Books.Commands.AddBook;
using BooksLibrary.Application.Books.Commands.AddBookOrder;
using BooksLibrary.Application.Books.Models;
using BooksLibrary.Domain.Books.Entities;
using Mapster;

namespace BooksLibrary.Application.Books
{
    public static class BooksMapping
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddBookCommand, Book>.NewConfig()
                .Map(d => d.GenreId, s => s.BookGenreId)
                .Map(d => d.PublishedYear, s => s.PublishedYear.Date);

            TypeAdapterConfig<AddBookOrderCommand, Book>.NewConfig()
                .Map(d => d.GenreId, s => s.BookGenreId)
                .Map(d => d.PublishedYear, s => s.PublishedYear.Date);

            TypeAdapterConfig<Book, BookResponseDto>.NewConfig()
                .Map(d => d.AuthorName, s => s.Author.Name)
                .Map(d => d.GenreName, s => s.Genre.Name)
                .Map(d => d.ExpectedDate, s => s.BookOrder.ExpectedDate);
        }
    }
}
