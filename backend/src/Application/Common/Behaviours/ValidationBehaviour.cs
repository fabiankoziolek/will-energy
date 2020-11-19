using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace WillEnergy.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehaviour<TRequest>> _logger;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehaviour<TRequest>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                _logger.LogError("Request Validation Exception: {@Errors}", ValidationBehaviourMessageMapper.Map(failures));
                throw new ValidationException(failures);
            }

            return Task.CompletedTask;
        }
    }
}
