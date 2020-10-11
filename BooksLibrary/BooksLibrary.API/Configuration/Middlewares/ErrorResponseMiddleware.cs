using System.Threading.Tasks;
using BooksLibrary.API.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BooksLibrary.API.Configuration.Middlewares
{
    public class ErrorResponseMiddleware
    {
        private RequestDelegate _next;

        public ErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IErrorResponseBuilder exceptionToStatusCodeConverter)
        {
            var exceptionContext = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionContext?.Error;

            var errorResponse = exceptionToStatusCodeConverter.GetErrorResponse(exception);

            context.Response.StatusCode = (int)errorResponse.StatusCode;
            context.Response.ContentType = "application/json";

            var serializedError = JsonConvert.SerializeObject(errorResponse);

            await context.Response.WriteAsync(serializedError);
        }
    }
}
