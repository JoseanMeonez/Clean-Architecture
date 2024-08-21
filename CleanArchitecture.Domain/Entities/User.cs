namespace Domain.Entities;

public partial class User : BaseEntity<Guid>
{
	public required string Name { get; set; }

	public required string LastName { get; set; }

	public required string UserName { get; set; }

	public required int GenderId { get; set; }

	public required byte[] PasswordHash { get; set; }

	public required byte[] PasswordSalt { get; set; }

	public required bool IsActive { get; set; }

	public virtual Gender? Gender { get; set; }
}
