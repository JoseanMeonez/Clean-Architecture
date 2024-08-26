using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
	public void Configure(EntityTypeBuilder<City> builder)
	{
		builder.HasKey(ci => ci.Id);

		builder.Property(ci => ci.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(ci => ci.DepartmentId)
			.IsRequired(false);

		builder.Property(ci => ci.RegionId)
			.IsRequired(false);

		// Relationships
		builder.HasOne(ci => ci.Department)
			.WithMany(d => d.Cities)
			.HasForeignKey(ci => ci.DepartmentId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(ci => ci.Region)
			.WithMany()
			.HasForeignKey(ci => ci.RegionId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasMany(ci => ci.Neighborhoods)
			.WithOne(n => n.City)
			.HasForeignKey(n => n.CityId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
