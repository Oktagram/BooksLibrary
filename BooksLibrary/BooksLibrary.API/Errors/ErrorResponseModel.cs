using System;
using System.Net;

namespace BooksLibrary.API.Errors
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {
        }

        public ErrorResponseModel(HttpStatusCode statusCode, string message, Exception ex)
        {
            StatusCode = statusCode;
            Message = message;
            Type = ex.GetType().Name;
            StackTrace = ex.ToString();
        }

        public HttpStatusCode StatusCode { get; }
        public string Type { get; }
        public string Message { get; }
        public string StackTrace { get; }
    }
}
