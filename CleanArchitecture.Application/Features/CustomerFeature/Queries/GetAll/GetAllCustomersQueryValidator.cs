using FluentValidation;

namespace Application.Features.CustomerFeature.Queries.GetAll;

public sealed class GetAllCustomersQueryValidator : AbstractValidator<GetAllCustomersQuery>
{
	public GetAllCustomersQueryValidator()
	{

	}
}
