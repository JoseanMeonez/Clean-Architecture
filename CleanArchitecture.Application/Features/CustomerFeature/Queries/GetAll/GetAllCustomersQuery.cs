using Application.Features.CustomerFeature.Responses;
using Application.Wrappers;
using MediatR;

namespace Application.Features.CustomerFeature.Queries.GetAll;

public sealed record GetAllCustomersQuery() : IRequest<Response<BasicCustomerResponse>>;

internal sealed class GetAllCustomersQueryHandler : IRequestHandler<
	GetAllCustomersQuery,
	Response<BasicCustomerResponse>>
{
	public Task<Response<BasicCustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
		=> throw new KeyNotFoundException($"No se encontraron registros.");
}
