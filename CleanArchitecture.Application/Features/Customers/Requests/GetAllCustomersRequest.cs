using Application.Features.Customers.Responses;
using Application.Mediator;
using Application.Parameters;
using Application.Wrappers;

namespace Application.Features.Customers.Requests;

public sealed record GetAllCustomersRequest : PaginatedRequestParameters, IRequest<Response<BasicCustomerResponse>>;
