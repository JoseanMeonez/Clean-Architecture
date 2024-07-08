using Application.Features.CustomerFeature.Responses;
using Application.Wrappers;
using Domain.Entities;
using Infrastructure.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Features.CustomerFeature.Queries.GetById;

public record GetCustomerByIdQuery(int Id) : IRequest<Response<BasicCustomerResponse>>;

internal class GetCustomerByIdHandler(
		ICustomerRepository customerRepository,
		IMapper mapper)
	: IRequestHandler<GetCustomerByIdQuery, Response<BasicCustomerResponse>>
{
	private readonly ICustomerRepository _customerRepository = customerRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<Response<BasicCustomerResponse>> Handle(
		GetCustomerByIdQuery request,
		CancellationToken cancellationToken)
	{
		Customer customer = await _customerRepository.GetByIdWithIncludes(request.Id)
			?? throw new KeyNotFoundException($"No se encontró el id {request.Id}");

		return new Response<BasicCustomerResponse>(
			_mapper.Map<BasicCustomerResponse>(customer),
			"Cliente encontrado.");
	}
}
