namespace Domain.Entities;

public partial class Country : BaseEntity<int>
{
	public required string Name { get; set; }

	public required string Abbreviation { get; set; }

	public ICollection<Department> Departments { get; set; } = [];
}
