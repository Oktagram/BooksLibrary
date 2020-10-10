using FluentValidation;
using MediatR;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Configuration.PipelineBehaviors
{
    public class ExceptionLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;

        public ExceptionLoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var name = typeof(TRequest).Name;
                var message = $"Exception in request: {name}, {request}";

                _logger.Error(ex, message);

                throw;
            }
        }
    }
}
