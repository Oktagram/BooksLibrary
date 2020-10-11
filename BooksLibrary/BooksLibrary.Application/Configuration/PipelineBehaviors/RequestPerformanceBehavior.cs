using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NLog;

namespace BooksLibrary.Application.Configuration.PipelineBehaviors
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _timer;

        public RequestPerformanceBehaviour(ILogger logger)
        {
            _logger = logger;

            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
                _logger.Warn($"Long Running Request: {request} ({_timer.ElapsedMilliseconds} milliseconds)");

            return response;
        }
    }
}
