using BooksLibrary.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Reader);
            builder.HasOne(u => u.Librarian);
            builder.HasOne(u => u.Role);

            builder
                .Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
