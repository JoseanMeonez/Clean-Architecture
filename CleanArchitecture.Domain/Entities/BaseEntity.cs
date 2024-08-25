namespace Domain.Entities;

public abstract class BaseEntity<TId>
{
	public required TId Id { get; init; }

	public required string CreatedBy { get; init; }

	public required DateTime CreationDate { get; init; }

	public string? UpdatedBy { get; set; }

	public DateTime? UpdateDate { get; set; }
}
