using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		builder.ToTable(nameof(Country));

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.Abbreviation)
			.IsRequired()
			.HasMaxLength(10);

		// Relationships
		builder.HasMany(c => c.Departments)
			.WithOne(d => d.Country)
			.HasForeignKey(d => d.CountryId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
