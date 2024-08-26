namespace Domain.Entities;

public partial class City : BaseEntity<int>
{
	public required string Name { get; set; }

	public int? DepartmentId { get; set; }

	public virtual Department? Department { get; set; }

	public int? RegionId { get; set; }

	public virtual Region? Region { get; set; }

	public virtual ICollection<Neighborhood> Neighborhoods { get; set; } = [];
}