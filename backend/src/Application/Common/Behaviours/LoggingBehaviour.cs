using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WillEnergy.Application.Common.Exceptions;
using WillEnergy.Domain.Exceptions;

namespace WillEnergy.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Request: {@Request}." + UserIdMessage(), request);

            _timer.Start();

            var response = default(TResponse);
            Exception responseException = null;

            try
            {
                response = await next();
            }
            catch (AppException exception)
            {
                _logger.LogError("Request {Status}: {Message}." + UserIdMessage(), exception.Status, exception.Message);
                responseException = exception;
            }
            catch (DomainException exception)
            {
                _logger.LogError("Domain Exception: {Message}." + UserIdMessage(), exception.Message);
                responseException = exception;
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogError("Request Concurrency Exception: {@Request}." + UserIdMessage(), request);
                responseException =
                    new ConflictException("Data have been modified since entities were loaded.");
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "Unexpected Server Exception." + UserIdMessage());
                responseException = new InternalServerErrorException();
            }

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 2000)
            {
                _logger.LogWarning(
                    "Request Performance Issue: {@Request} ({ElapsedMilliseconds} milliseconds)." + UserIdMessage(),
                    request,
                    _timer.ElapsedMilliseconds);
            }

            if (responseException != null)
            {
                throw responseException;
            }

            return response;
        }

        private static string UserIdMessage()
        {
            return string.Empty;
        }
    }
}
