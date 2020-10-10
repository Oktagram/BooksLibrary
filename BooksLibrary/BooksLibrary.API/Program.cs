using System;
using BooksLibrary.API.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BooksLibrary.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = ApplicationLogger.GetApplicationStartLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Exception on application startup");
                throw;
            }
            finally
            {
                ApplicationLogger.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
