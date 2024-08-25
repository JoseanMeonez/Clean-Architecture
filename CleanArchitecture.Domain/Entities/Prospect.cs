namespace Domain.Entities;

public partial class Prospect : BaseEntity<int>
{
	public required string Name { get; set; }

	public required string LastName { get; set; }

	public string? MarriedLastName { get; set; }

	public required string Address { get; set; }

	public required int GenderId { get; set; }

	public required int NationalityId { get; set; }

	public required int IdentificationTypeId { get; set; }

	public required string IdentificationValue { get; set; }

	public required string PhoneNumber { get; set; }

	public required string PhoneNumberDesc { get; set; }

	public required string Email { get; set; }

	public required string EmailDesc { get; set; }

	public required int NeighborhoodId { get; set; }

	public virtual ICollection<Customer> Customers { get; set; } = [];
}
