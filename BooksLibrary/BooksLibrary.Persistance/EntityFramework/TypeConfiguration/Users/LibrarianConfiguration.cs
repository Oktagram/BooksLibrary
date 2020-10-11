using System;
using System.Collections.Generic;
using System.Text;
using BooksLibrary.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Users
{
    public class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.User);

            builder
                .Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasMany(l => l.LentBooks);
        }
    }
}
