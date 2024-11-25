using Application.Features.Customers.Requests;
using Application.Features.Customers.Responses;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Customers.Queries.GetAll;

internal sealed class GetAllCustomersQueryHandler : IRequestHandler<
	GetAllCustomersQuery,
	Response<BasicCustomerResponse>>
{
	public Task<Response<BasicCustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
		=> throw new NotImplementedException();
}
