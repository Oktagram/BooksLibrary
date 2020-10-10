using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace BooksLibrary.API.Configuration
{
    public static class ApplicationLogger
    {
        public static ILogger GetApplicationStartLogger()
        {
            return LogManager
                .LoadConfiguration("NLog.config")
                .GetLogger("ApplicationStart");
        }

        public static IServiceCollection AddNLogDependency(this IServiceCollection services)
        {
            var databaseLogger = LogManager.GetLogger("Database");

            services.AddSingleton<ILogger>(databaseLogger);

            return services;
        }

        public static IServiceCollection ConfigureNLog(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            LogManager.Configuration.Variables.Add("connectionString", connectionString);

            return services;
        }

        public static void Shutdown()
        {
            LogManager.Shutdown();
        }
    }
}
