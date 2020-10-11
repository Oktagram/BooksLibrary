using BooksLibrary.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksLibrary.Persistance.EntityFramework.TypeConfiguration.Logs
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Level)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(l => l.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .Property(l => l.Login)
                .IsRequired(false);

            builder
                .Property(l => l.CallSite)
                .IsRequired(false)
                .HasMaxLength(200);

            builder
                .Property(l => l.Exception)
                .IsRequired(false);
        }
    }
}
