using BooksLibrary.Domain;
using BooksLibrary.Domain.Entities;
using BooksLibrary.Domain.Users;
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
            modelBuilder
                .Entity<BorrowedBook>()
                .HasOne(bb => bb.Reader)
                .WithMany(r => r.BorrowedBooks)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
