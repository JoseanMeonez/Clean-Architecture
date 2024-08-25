namespace Domain.Entities;

public partial class IdentificationType : BaseEntity<int>
{
	public required string Name { get; set; }

	public virtual ICollection<Customer> Customers { get; set; } = [];
}
