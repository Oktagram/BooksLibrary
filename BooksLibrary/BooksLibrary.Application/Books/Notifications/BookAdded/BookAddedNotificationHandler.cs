using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace BooksLibrary.Application.Books.Notifications.BookAdded
{
    public class BookAddedNotificationHandler : Hub, INotificationHandler<BookAddedNotification>
    {
        private readonly IHubContext<BookAddedNotificationHandler> _hubContext;

        public BookAddedNotificationHandler(IHubContext<BookAddedNotificationHandler> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(BookAddedNotification notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("BookAdded", notification.BookId, cancellationToken);
        }
    }
}
