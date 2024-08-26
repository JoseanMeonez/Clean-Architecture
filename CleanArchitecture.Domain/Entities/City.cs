namespace Domain.Entities;

public partial class City : BaseEntity<int>
{
	public required string Name { get; set; }

	public int? DepartmentId { get; set; }

	public Department? Department { get; set; }
}