using FluentValidation;

namespace Application.Features.CustomerFeature.Queries.GetById;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
	public GetCustomerByIdQueryValidator()
	{
		RuleFor(c => c.Id)
			.NotNull().WithMessage("{PropertyName} es inválido.")
			.WithName("El ID del cliente");
	}
}
