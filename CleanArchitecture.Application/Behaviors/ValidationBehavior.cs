using Application.Mediator;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
		where TRequest : IRequest<TResponse>
{
	private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

	public async Task<TResponse> Handle(
			TRequest request,
			Func<Task<TResponse>> next,
			CancellationToken cancellationToken)
	{
		if (_validators.Any())
		{
			ValidationContext<TRequest> context = new(request);

			ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

			IEnumerable<ValidationFailure> failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null);

			if (failures.Any())
			{
				throw new Exceptions.ValidationException(failures);
			}
		}

		return await next();
	}
}
