using BooksLibrary.API.Configuration;
using BooksLibrary.API.Configuration.Middlewares;
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

            services.AddControllers();

            services.AddSwaggerGen();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
