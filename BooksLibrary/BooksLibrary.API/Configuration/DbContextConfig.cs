using BooksLibrary.Persistance.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibrary.API.Configuration
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
