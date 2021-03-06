﻿using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BooksLibrary.Application.Exceptions;
using NLog;

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
            catch (Exception ex) when (ex is ValidationException || ex is NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var message = $"Exception in request: {request} {ex.Message}";

                _logger.Error(ex, message);

                throw;
            }
        }
    }
}
