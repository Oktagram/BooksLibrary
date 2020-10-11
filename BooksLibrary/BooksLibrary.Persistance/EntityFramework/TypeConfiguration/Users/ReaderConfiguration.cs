using BooksLibrary.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Users
{
    public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.User);

            builder
                .HasMany(r => r.BorrowedBooks)
                .WithOne(b => b.Reader)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r => r.BookOrders);

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
