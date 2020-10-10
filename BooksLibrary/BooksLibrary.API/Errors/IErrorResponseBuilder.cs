using System;

namespace BooksLibrary.API.Errors
{
    public interface IErrorResponseBuilder
    {
        ErrorResponseModel GetErrorResponse(Exception ex);
    }
}
