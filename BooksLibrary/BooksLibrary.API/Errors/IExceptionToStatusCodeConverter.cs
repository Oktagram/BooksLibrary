using System;
using System.Net;

namespace BooksLibrary.API.Errors
{
    public interface IExceptionToStatusCodeConverter
    {
        HttpStatusCode GetHttpStatusCode(Exception ex);
    }
}
