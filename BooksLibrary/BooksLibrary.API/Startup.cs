using System.Text.Json.Serialization;
using BooksLibrary.API.Configuration;
using BooksLibrary.API.Configuration.Middlewares;
using BooksLibrary.Application.Books.Notifications.BookAdded;
using BooksLibrary.Application.Books.Notifications.BookOrdered;
using BooksLibrary.Application.Books.Notifications.BookRemoved;
using BooksLibrary.Application.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration);

            services
                .ConfigureNLog(Configuration)
                .AddNLogDependency();

            services
                .AddApplicationDependencies()
                .AddApiDependencies();

            services
                .AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwagger();

            services.AddJwtAuthentication();

            services.AddSignalR();

            ApplicationMapsterConfiguration.Configure();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.UseMiddleware<ErrorResponseMiddleware>();
            });

            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksLibrary API v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");

                endpoints.MapHub<BookAddedNotificationHandler>("/book-added");
                endpoints.MapHub<BookRemovedNotificationHandler>("/book-removed");
                endpoints.MapHub<BookOrderedNotificationHandler>("/book-ordered");
            });
        }
    }
}
