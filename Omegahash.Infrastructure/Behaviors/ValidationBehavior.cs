using FluentValidation;
using MediatR;
using Omegahash.Infrastructure.Commands;

namespace Omegahash.Infrastructure.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var errors = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors);

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}
