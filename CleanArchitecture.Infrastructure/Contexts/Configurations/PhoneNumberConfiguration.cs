﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;
internal class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
	public void Configure(EntityTypeBuilder<PhoneNumber> entity)
	{
		entity.ToTable("PhoneNumber");

		entity.HasKey(e => e.Id);

		entity.Property(e => e.Description)
			.HasMaxLength(50)
			.IsUnicode(false);

		entity.Property(e => e.Number)
			.HasMaxLength(8)
			.IsUnicode(false)
			.HasColumnName("Number");

		entity.HasOne(d => d.Customer).WithMany(p => p.PhoneNumbers)
			.HasForeignKey(d => d.CustomerId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_PhoneNumber_Customer");
	}
}
