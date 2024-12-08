using Application.Features.Customers.Requests;
using FluentValidation;

namespace Application.Features.Customers.Queries.GetById;

internal sealed class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdRequest>
{
	public GetCustomerByIdQueryValidator()
	{
		RuleFor(c => c.Id)
			.NotNull().WithMessage("{PropertyName} es inválido.")
			.WithName("El ID del cliente");
	}
}
