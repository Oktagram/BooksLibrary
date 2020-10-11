using BooksLibrary.Application.Books.Commands.AddBook;
using BooksLibrary.Domain.Books.Entities;
using Mapster;

namespace BooksLibrary.Application.Books
{
    public static class BooksMapping
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddBookCommand, Book>.NewConfig()
                .Map(d => d.GenreId, s => s.BookGenreId);
        }
    }
}
