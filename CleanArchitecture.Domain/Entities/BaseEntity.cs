namespace Domain.Entities;

public abstract class BaseEntity<TId>
{
	public required TId Id { get; init; }

	public bool Active { get; set; }

	public bool Deleted { get; set; }

	public required string CreatedBy { get; init; }

	public required Guid CreatedById { get; init; }

	public required DateTime CreationDate { get; init; }

	public string? UpdatedBy { get; set; }

	public Guid? UpdatedById { get; set; }

	public DateTime? UpdateDate { get; set; }

	public string? DeletedBy { get; }

	public Guid? DeletedById { get; }

	public DateTime? DeletedDate { get; }
}
