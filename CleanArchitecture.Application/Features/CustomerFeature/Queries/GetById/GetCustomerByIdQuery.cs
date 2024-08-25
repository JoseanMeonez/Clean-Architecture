using Application.Features.CustomerFeature.Responses;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.CustomerFeature.Queries.GetById;

public sealed record GetCustomerByIdQuery(int Id) : IRequest<Response<BasicCustomerResponse>>;

internal sealed class GetCustomerByIdHandler(
	ICustomerRepository customerRepository,
	IMapper mapper)
	: IRequestHandler<GetCustomerByIdQuery, Response<BasicCustomerResponse>>
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
