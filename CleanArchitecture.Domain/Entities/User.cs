﻿namespace Domain.Entities;

public partial class User : BaseEntity<Guid>
{
	public required string Name { get; set; }

	public required string LastName { get; set; }

	public required string UserName { get; set; }

	public int GenderId { get; set; }

	public required byte[] PasswordHash { get; set; }

	public required byte[] PasswordSalt { get; set; }

	public required byte[] MasterPasswordHash { get; set; }

	public required byte[] MasterPasswordSalt { get; set; }

	public bool IsActive { get; set; }

	public virtual Gender? Gender { get; set; }
}
