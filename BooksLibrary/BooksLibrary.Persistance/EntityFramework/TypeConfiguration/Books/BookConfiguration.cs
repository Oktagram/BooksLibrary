using BooksLibrary.Domain.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Books
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Author);
            builder.HasOne(b => b.Genre);
            builder.HasOne(b => b.BookOrder);

            builder
                .Property(b => b.Status)
                .IsRequired();

            builder
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(b => b.PagesCount)
                .IsRequired();
        }
    }
}
