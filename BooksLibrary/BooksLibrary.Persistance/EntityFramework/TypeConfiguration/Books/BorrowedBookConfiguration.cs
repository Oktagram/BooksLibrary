using BooksLibrary.Domain.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Books
{
    public class BorrowedBookConfiguration : IEntityTypeConfiguration<BorrowedBook>
    {
        public void Configure(EntityTypeBuilder<BorrowedBook> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Book);
            builder.HasOne(b => b.Reader);
            builder.HasOne(b => b.Librarian);
        }
    }
}
