using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Domain.Authors;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Logs;
using BooksLibrary.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Application.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookGenre> BookGenres { get; set; }
        DbSet<BookOrder> BookOrders { get; set; }
        DbSet<BorrowedBook> BorrowedBooks { get; set; }
        DbSet<Librarian> Librarians { get; set; }
        DbSet<Reader> Readers { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Log> Logs { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}