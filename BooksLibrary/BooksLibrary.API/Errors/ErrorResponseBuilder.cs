using BooksLibrary.Application.Exceptions;
using FluentValidation;
using System;
using System.Linq;
using System.Net;

namespace BooksLibrary.API.Errors
{
    public class ErrorResponseBuilder : IErrorResponseBuilder
    {
        public ErrorResponseModel GetErrorResponse(Exception ex)
        {
            if (ex is null)
                return new ErrorResponseModel();

            if (ex is ValidationException validationEx)
            {
                var errorMessages = validationEx.Errors.Select(e => e.ErrorMessage);
                var message = string.Join(' ', errorMessages);
                return new ErrorResponseModel(HttpStatusCode.BadRequest, message, validationEx);
            }

            var statusCode = GetStatusCode(ex);

            return new ErrorResponseModel(statusCode, ex.Message, ex);
        }

        private HttpStatusCode GetStatusCode(Exception ex)
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
