using Application.Features.Customers.Requests;
using FluentValidation;

namespace Application.Features.Customers.Queries.GetAll;

public sealed class GetAllCustomersQueryValidator : AbstractValidator<GetAllCustomersRequest>
{
	public GetAllCustomersQueryValidator()
	{

	}
}
