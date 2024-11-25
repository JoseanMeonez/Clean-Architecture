namespace Application.Features.Customers.Responses;

internal record BasicCustomerResponse(
	int Id,
	string Name,
	string LastName,
	string? MarriedLastName,
	string Address,
	int GenderId,
	string GenderName,
	int NationalityId,
	int IdentificationTypeId,
	string IdentificationTypeName,
	string IdentificationValue,
	int NeighborhoodId,
	int? ProspectId);
