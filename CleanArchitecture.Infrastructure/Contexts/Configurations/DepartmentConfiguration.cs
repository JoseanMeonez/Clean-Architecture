using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
	public void Configure(EntityTypeBuilder<Department> builder)
	{
		builder.HasKey(d => d.Id);

		builder.Property(d => d.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(d => d.CountryId)
			.IsRequired(false);

		// Relationships
		builder.HasOne(d => d.Country)
			.WithMany(c => c.Departments)
			.HasForeignKey(d => d.CountryId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(d => d.Cities)
			.WithOne(ci => ci.Department)
			.HasForeignKey(ci => ci.DepartmentId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
