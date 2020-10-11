using MediatR;

namespace BooksLibrary.Application.Books.Notifications.BookRemoved
{
    public class BookRemovedNotification : INotification
    {
        public int BookId { get; set; }
    }
}
