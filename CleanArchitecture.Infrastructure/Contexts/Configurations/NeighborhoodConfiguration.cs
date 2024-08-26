using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
{
	public void Configure(EntityTypeBuilder<Neighborhood> builder)
	{
		builder.ToTable(nameof(Neighborhood));

		builder.HasKey(n => n.Id);

		builder.Property(n => n.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(n => n.CityId)
			.IsRequired(false);

		// Relationships
		builder.HasOne(n => n.City)
			.WithMany(ci => ci.Neighborhoods)
			.HasForeignKey(n => n.CityId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
