using ErrorOr;
using FluentValidation;
using MediatR;

namespace PharmaPOS.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next(cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count == 0)
        {
            return await next(cancellationToken);
        }

        var errors = failures.ConvertAll(failure => 
        {
            var propertyName = failure.PropertyName;
            if (propertyName.StartsWith("Request."))
            {
                propertyName = propertyName.Substring(8); // Remove "Request."
            }
            
            return Error.Validation(propertyName, failure.ErrorMessage);
        });

        // Use reflection to return the TResponse (which is ErrorOr<T>)
        return (dynamic)errors;
    }
}
