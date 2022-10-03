using MediatR;
using ErrorOr;
using FluentValidation;

namespace BuberDinner.Application.Common.Behaviors;

// this step in the pipeline validates the data before the request are made
public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    // default initialized as null in case a certain request doesn't have a validator, and if so, in the Handle will just go to the next one
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

        return (dynamic)errors;
    }
}