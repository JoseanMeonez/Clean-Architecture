namespace Domain.Entities;

public partial class Reference : BaseEntity<int>
{
	public required string Name { get; set; }

	public required string PhoneNumber { get; set; }

	public required string Relationship { get; set; }

	public required Guid CustomerId { get; set; }

	public virtual Customer? Customer { get; set; }
}
