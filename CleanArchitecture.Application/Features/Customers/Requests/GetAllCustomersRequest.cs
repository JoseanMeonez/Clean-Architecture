using Application.Features.Customers.Responses;
using Application.Parameters;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Customers.Requests;

public sealed record GetAllCustomersRequest : PaginatedRequestParameters, IRequest<Response<BasicCustomerResponse>>;
