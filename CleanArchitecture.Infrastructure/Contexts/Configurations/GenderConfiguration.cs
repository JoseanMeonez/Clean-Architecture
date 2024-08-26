using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
	public void Configure(EntityTypeBuilder<Gender> builder)
	{
		builder.ToTable(nameof(Gender));

		builder.HasKey(g => g.Id);

		builder.Property(g => g.Name)
			.IsRequired()
			.HasMaxLength(50);

		// Relationships
		builder.HasMany(g => g.Customers)
			.WithOne(c => c.Gender)
			.HasForeignKey(c => c.GenderId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
