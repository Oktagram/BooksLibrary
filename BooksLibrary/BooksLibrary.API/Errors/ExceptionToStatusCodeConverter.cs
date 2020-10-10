using BooksLibrary.Application.Exceptions;
using System;
using System.Net;

namespace BooksLibrary.API.Errors
{
    public class ExceptionToStatusCodeConverter : IExceptionToStatusCodeConverter
    {
        public HttpStatusCode GetHttpStatusCode(Exception ex)
        {
            switch (ex)
            {
                case UnauthorizedException _:
                    return HttpStatusCode.Unauthorized;

                case AccessDeniedException _:
                    return HttpStatusCode.Forbidden;

                case NotFoundException _:
                    return HttpStatusCode.NotFound;

                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
