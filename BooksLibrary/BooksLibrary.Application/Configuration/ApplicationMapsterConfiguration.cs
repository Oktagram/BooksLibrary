using BooksLibrary.Application.Books;

namespace BooksLibrary.Application.Configuration
{
    public static class ApplicationMapsterConfiguration
    {
        public static void Configure()
        {
            BooksMapping.Configure();
        }
    }
}
