using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
	public void Configure(EntityTypeBuilder<City> builder)
	{
		builder.ToTable(nameof(City));

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
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(ci => ci.Region)
			.WithMany()
			.HasForeignKey(ci => ci.RegionId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(ci => ci.Neighborhoods)
			.WithOne(n => n.City)
			.HasForeignKey(n => n.CityId)
			.OnDelete(DeleteBehavior.Cascade);

		// Auditable fields
		builder.Property(e => e.Active)
			.IsRequired();

		builder.Property(e => e.Deleted)
			.IsRequired();

		builder.Property(e => e.CreatedBy)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(e => e.CreatedById)
			.IsRequired(false);

		builder.Property(e => e.CreationDate)
			.IsRequired();

		builder.Property(e => e.UpdatedBy)
			.HasMaxLength(100);

		builder.Property(e => e.UpdatedById)
			.IsRequired(false);

		builder.Property(e => e.UpdateDate)
			.IsRequired(false);

		builder.Property(e => e.DeletedBy)
			.HasMaxLength(100);

		builder.Property(e => e.DeletedById)
			.IsRequired(false);

		builder.Property(e => e.DeletedDate)
			.IsRequired(false);

		builder.HasOne(e => e.CreatedByUser)
			.WithMany()
			.HasForeignKey(e => e.CreatedById)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(e => e.UpdatedByUser)
			.WithMany()
			.HasForeignKey(e => e.UpdatedById)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(e => e.DeletedByUser)
			.WithMany()
			.HasForeignKey(e => e.DeletedById)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
