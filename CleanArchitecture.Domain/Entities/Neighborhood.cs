namespace Domain.Entities;

public partial class Neighborhood : BaseEntity<int>
{
	public required string Name { get; set; }

	public int? CityId { get; set; }

	public virtual City? City { get; set; }
}