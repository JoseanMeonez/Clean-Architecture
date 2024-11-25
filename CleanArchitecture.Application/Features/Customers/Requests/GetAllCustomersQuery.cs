using Application.Features.Customers.Responses;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Customers.Requests;

public sealed record GetAllCustomersQuery() : IRequest<Response<BasicCustomerResponse>>;
