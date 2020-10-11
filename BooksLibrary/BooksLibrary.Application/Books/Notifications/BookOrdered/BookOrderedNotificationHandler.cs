using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace BooksLibrary.Application.Books.Notifications.BookOrdered
{
    public class BookOrderedNotificationHandler : Hub, INotificationHandler<BookOrderedNotificaiton>
    {
        private readonly IHubContext<BookOrderedNotificationHandler> _hubContext;

        public BookOrderedNotificationHandler(IHubContext<BookOrderedNotificationHandler> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(BookOrderedNotificaiton notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("BookOrdered", notification.BookId, cancellationToken);
        }
    }
}
