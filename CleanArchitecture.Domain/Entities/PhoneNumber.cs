namespace Domain.Entities;

public partial class PhoneNumber : BaseEntity<int>
{
	public required string Description { get; set; }

	public required string Number { get; set; }

	public required Guid CustomerId { get; set; }

	public virtual Customer? Customer { get; set; }
}
