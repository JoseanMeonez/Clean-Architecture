using Application.Features.Customers.Responses;
using Application.Mediator;
using Application.Wrappers;

namespace Application.Features.Customers.Requests;

public sealed record GetCustomerByIdRequest(Guid Id) : IRequest<Response<BasicCustomerResponse>>;
