using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class RegionConfiguration : IEntityTypeConfiguration<Region>
{
	public void Configure(EntityTypeBuilder<Region> builder)
	{
		builder.ToTable(nameof(Region));

		builder.HasKey(r => r.Id);

		builder.Property(r => r.Name)
			.IsRequired()
			.HasMaxLength(100);

		// Relationships
		builder.HasMany(r => r.Cities)
			.WithOne(ci => ci.Region)
			.HasForeignKey(ci => ci.RegionId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
