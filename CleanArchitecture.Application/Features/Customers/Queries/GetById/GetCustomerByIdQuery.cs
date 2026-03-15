using Application.Features.Customers.Requests;
using Application.Features.Customers.Responses;
using Application.Mediator;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Interfaces;
using MapsterMapper;

namespace Application.Features.Customers.Queries.GetById;

internal sealed class GetCustomerByIdHandler(
		ICustomerRepository customerRepository,
		IMapper mapper) : IRequestHandler<GetCustomerByIdRequest, Response<BasicCustomerResponse>>
{
	public async Task<Response<BasicCustomerResponse>> Handle(
			GetCustomerByIdRequest request,
			CancellationToken cancellationToken)
	{
		// Search for the client by ID using the repository
		Customer customer = await customerRepository.GetByIdWithIncludes(request.Id)
				?? throw new KeyNotFoundException($"No se encontró el id {request.Id}");

		// Map Customer entity to BasicCustomerResponse
		BasicCustomerResponse customerResponse = mapper.Map<BasicCustomerResponse>(customer);

		// Return the response wrapped in the Response object
		return new Response<BasicCustomerResponse>(customerResponse, "Cliente encontrado.");
	}
}
