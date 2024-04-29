﻿namespace Domain.Entities;

public abstract class BaseEntity<TId>
{
	public required TId Id { get; init; }
}
