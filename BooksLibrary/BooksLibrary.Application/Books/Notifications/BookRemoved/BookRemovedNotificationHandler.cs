using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace BooksLibrary.Application.Books.Notifications.BookRemoved
{
    public class BookRemovedNotificationHandler : Hub, INotificationHandler<BookRemovedNotification>
    {
        private readonly IHubContext<BookRemovedNotificationHandler> _hubContext;

        public BookRemovedNotificationHandler(IHubContext<BookRemovedNotificationHandler> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(BookRemovedNotification notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("BookRemoved", notification.BookId, cancellationToken);
        }
    }
}
