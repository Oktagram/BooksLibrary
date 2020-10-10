using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BooksLibrary.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
