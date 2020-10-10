using System;

namespace BooksLibrary.API.Errors
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {
        }

        public ErrorResponseModel(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
        }

        public string Type { get; }
        public string Message { get; }
        public string StackTrace { get; }
    }
}
