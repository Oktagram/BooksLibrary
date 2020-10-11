using MediatR;

namespace BooksLibrary.Application.Books.Notifications.BookOrdered
{
    public class BookOrderedNotificaiton : INotification
    {
        public int BookId { get; set; }
    }
}
