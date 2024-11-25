using Application.Features.Customers.Requests;
using Application.Features.Customers.Responses;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.Customers.Queries.GetById;

internal sealed class GetCustomerByIdHandler(
	ICustomerRepository customerRepository,
	IMapper mapper) : IRequestHandler<GetCustomerByIdQuery, Response<BasicCustomerResponse>>
{
	public async Task<Response<BasicCustomerResponse>> Handle(
		GetCustomerByIdQuery request,
		CancellationToken cancellationToken)
	{
		Customer customer = await customerRepository.GetByIdWithIncludes(request.Id)
			?? throw new KeyNotFoundException($"No se encontró el id {request.Id}");

		return new Response<BasicCustomerResponse>(
			mapper.Map<BasicCustomerResponse>(customer),
			"Cliente encontrado.");
	}
}
