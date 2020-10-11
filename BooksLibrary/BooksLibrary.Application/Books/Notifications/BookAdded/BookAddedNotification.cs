using MediatR;

namespace BooksLibrary.Application.Books.Notifications.BookAdded
{
    public class BookAddedNotification : INotification
    {
        public int BookId { get; set; }
    }
}
