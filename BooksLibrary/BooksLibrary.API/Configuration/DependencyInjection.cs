using BooksLibrary.API.Errors;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibrary.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddScoped<IExceptionToStatusCodeConverter, ExceptionToStatusCodeConverter>();

            return services;
        }
    }
}
