namespace Domain.Entities;

public partial class Customer : BaseEntity<Guid>
{
	public required string Name { get; set; }

	public required string LastName { get; set; }

	public string? MarriedLastName { get; set; }

	public required string Address { get; set; }

	public required string IdentificationValue { get; set; }

	public required int GenderId { get; set; }

	public int? ProspectId { get; set; }

	public required int CountryId { get; set; }

	public required int IdentificationTypeId { get; set; }

	public int? NeighborhoodId { get; set; }

	public int? CityId { get; set; }

	public int? DepartmentId { get; set; }

	public virtual Gender? Gender { get; set; }

	public virtual Prospect? Prospect { get; set; }

	public virtual Country? Country { get; set; }

	public virtual IdentificationType? IdentificationType { get; set; }

	public virtual Neighborhood? Neighborhood { get; set; }

	public virtual City? City { get; set; }

	public virtual Department? Department { get; set; }

	public virtual ICollection<Email> Emails { get; set; } = [];

	public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = [];

	public virtual ICollection<Reference> References { get; set; } = [];
}
