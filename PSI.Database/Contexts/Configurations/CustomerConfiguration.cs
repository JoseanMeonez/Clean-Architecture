﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSI.Domain.Entities;

namespace PSI.Infrastructure.Contexts.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> entity)
	{
		entity.ToTable("Customer");

		entity.HasKey(e => e.Id);

		entity.Property(e => e.Address)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.IdentificationValue)
			.HasMaxLength(50)
			.IsUnicode(false);

		entity.Property(e => e.LastName)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.MarriedLastName)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.Name)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.HasOne(d => d.Gender).WithMany(p => p.Customers)
			.HasForeignKey(d => d.GenderId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Customer_Gender");

		entity.HasOne(d => d.IdentificationType).WithMany(p => p.Customers)
			.HasForeignKey(d => d.IdentificationTypeId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName("FK_Customer_IdentificationType");

		entity.HasOne(d => d.Prospect).WithMany(p => p.Customers)
			.HasForeignKey(d => d.ProspectId)
			.HasConstraintName("FK_Customer_Prospect");
	}
}
