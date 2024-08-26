using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.LastName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.MarriedLastName)
			.HasMaxLength(100);

		builder.Property(c => c.Address)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(c => c.IdentificationValue)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(c => c.GenderId)
			.IsRequired();

		builder.Property(c => c.ProspectId)
			.IsRequired(false);

		builder.Property(c => c.CountryId)
			.IsRequired();

		builder.Property(c => c.IdentificationTypeId)
			.IsRequired();

		builder.Property(c => c.NeighborhoodId)
			.IsRequired(false);

		builder.Property(c => c.CityId)
			.IsRequired(false);

		builder.Property(c => c.DepartmentId)
			.IsRequired(false);

		// Relationships
		builder.HasOne(c => c.Gender)
			.WithMany()
			.HasForeignKey(c => c.GenderId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(c => c.Prospect)
			.WithMany()
			.HasForeignKey(c => c.ProspectId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(c => c.Country)
			.WithMany()
			.HasForeignKey(c => c.CountryId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(c => c.IdentificationType)
			.WithMany()
			.HasForeignKey(c => c.IdentificationTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(c => c.Neighborhood)
			.WithMany()
			.HasForeignKey(c => c.NeighborhoodId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(c => c.City)
			.WithMany()
			.HasForeignKey(c => c.CityId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(c => c.Department)
			.WithMany()
			.HasForeignKey(c => c.DepartmentId)
			.OnDelete(DeleteBehavior.SetNull);

		// Collections
		builder.HasMany(c => c.Emails)
			.WithOne()
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(c => c.PhoneNumbers)
			.WithOne()
			.HasForeignKey(p => p.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(c => c.References)
			.WithOne()
			.HasForeignKey(r => r.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
