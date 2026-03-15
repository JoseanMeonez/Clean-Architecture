using Application.Features.Customers.Requests;
using Application.Features.Customers.Responses;
using Application.Mediator;
using Application.Wrappers;

namespace Application.Features.Customers.Queries.GetAll;

internal sealed class GetAllCustomersQueryHandler : IRequestHandler<
		GetAllCustomersRequest,
		Response<BasicCustomerResponse>>
{
	public Task<Response<BasicCustomerResponse>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
			=> throw new NotImplementedException();
}
