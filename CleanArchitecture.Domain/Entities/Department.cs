namespace Domain.Entities;

public partial class Department : BaseEntity<int>
{
	public required string Name { get; set; }

	public int? CountryId { get; set; }

	public Country? Country { get; set; }

	public ICollection<City> Cities { get; set; } = [];
}