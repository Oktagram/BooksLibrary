using BooksLibrary.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Authors
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Books);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
