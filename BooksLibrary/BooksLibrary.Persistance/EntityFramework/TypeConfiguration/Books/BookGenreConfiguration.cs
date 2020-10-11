using BooksLibrary.Domain.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Books
{
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasMany(g => g.Books);

            builder
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
