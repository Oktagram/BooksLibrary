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

        public HttpStatusCode StatusCode { get; private set; }
        public string Type { get; private set; }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
    }
}
