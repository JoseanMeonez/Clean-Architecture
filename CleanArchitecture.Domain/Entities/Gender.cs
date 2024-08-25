namespace Domain.Entities;

public partial class Gender : BaseEntity<int>
{
	public required string Name { get; set; }

	public virtual ICollection<Customer> Customers { get; set; } = [];
}
