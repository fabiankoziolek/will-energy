using System;
using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using WillEnergy.Application.Common.Behaviours;
using WillEnergy.Application.Common.Exceptions;
using WillEnergy.Domain.Exceptions;

namespace WillEnergy.WebUI.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(DomainException), HandleDomainException },
                { typeof(BadRequestException), HandleApplicationException },
                { typeof(ConflictException), HandleApplicationException },
                { typeof(InternalServerErrorException), HandleApplicationException },
                { typeof(NotFoundException), HandleApplicationException },
                { typeof(ForbiddenException), HandleApplicationException },
            };
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private static void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new ValidationProblemDetails(ValidationBehaviourMessageMapper.Map(exception!.Errors))
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "Validation failed.",
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private static void HandleDomainException(ExceptionContext context)
        {
            var exception = context.Exception as DomainException;

            var details = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                Status = StatusCodes.Status409Conflict,
                Title = exception?.Message,
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status409Conflict,
            };

            context.ExceptionHandled = true;
        }

        private static void HandleApplicationException(ExceptionContext context)
        {
            var exception = context.Exception as AppException;

            var details = new ProblemDetails
            {
                Type = exception?.RfcType,
                Status = (int)exception?.Status!,
                Title = exception.Message,
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = (int)exception.Status,
            };

            context.ExceptionHandled = true;
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };

            context.ExceptionHandled = true;
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            _logger.LogCritical(context.Exception, "Unexpected Web Layer Exception.");
            HandleUnknownException(context);
        }
    }
}
