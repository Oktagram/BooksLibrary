using BooksLibrary.Domain.Authors;
using BooksLibrary.Domain.Books.Entities;
using BooksLibrary.Domain.Logs;
using BooksLibrary.Domain.Users;
using BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Authors;
using BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Books;
using BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Logs;
using BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Users;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Persistance.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookOrderConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowedBookConfiguration());

            modelBuilder.ApplyConfiguration(new LogConfiguration());

            modelBuilder.ApplyConfiguration(new LibrarianConfiguration());
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
