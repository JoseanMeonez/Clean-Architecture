﻿namespace Domain.Entities;

public partial class Department : BaseEntity<int>
{
	public required string Name { get; set; }

	public int? CountryId { get; set; }

	public virtual Country? Country { get; set; }

	public virtual ICollection<City> Cities { get; set; } = [];
}