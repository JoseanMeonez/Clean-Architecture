namespace Domain.Entities;

public partial class Region : BaseEntity<int>
{
	public required string Name { get; set; }

	public virtual ICollection<City> Cities { get; set; } = [];
}