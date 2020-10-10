using BooksLibrary.API.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly IExceptionToStatusCodeConverter _exceptionToStatusCodeConverter;

        public ErrorsController(IExceptionToStatusCodeConverter exceptionToStatusCodeConverter)
        {
            _exceptionToStatusCodeConverter = exceptionToStatusCodeConverter;
        }

        [HttpGet("/error")]
        public ErrorResponseModel Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var httpStatusCode = _exceptionToStatusCodeConverter.GetHttpStatusCode(exception);

            Response.StatusCode = (int)httpStatusCode;

            return exception is null
                ? new ErrorResponseModel()
                : new ErrorResponseModel(exception);
        }
    }
}
