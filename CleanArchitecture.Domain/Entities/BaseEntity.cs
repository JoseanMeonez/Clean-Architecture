namespace Domain.Entities;

public abstract class BaseEntity<TId>
{
	public required TId Id { get; init; }

	public bool Active { get; set; }

	public bool Deleted { get; set; }

	public required string CreatedBy { get; init; }

	public Guid? CreatedById { get; init; }

	public User? CreatedByUser { get; init; }

	public required DateTime CreationDate { get; init; }

	public string? UpdatedBy { get; set; }

	public Guid? UpdatedById { get; set; }

	public User? UpdatedByUser { get; set; }

	public DateTime? UpdateDate { get; set; }

	public string? DeletedBy { get; set; }

	public Guid? DeletedById { get; set; }

	public User? DeletedByUser { get; set; }

	public DateTime? DeletedDate { get; set; }
}
