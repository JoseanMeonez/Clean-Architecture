namespace Domain.Entities;

public partial class Email : BaseEntity<int>
{
	public required string Description { get; set; }

	public required string EmailName { get; set; }

	public required int CustomerId { get; set; }

	public virtual Customer? Customer { get; set; }
}
