using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationType>
{
	public void Configure(EntityTypeBuilder<IdentificationType> builder)
	{
		builder.HasKey(it => it.Id);

		builder.Property(it => it.Name)
			.IsRequired()
			.HasMaxLength(50);

		// Relationships
		builder.HasMany(it => it.Customers)
			.WithOne(c => c.IdentificationType)
			.HasForeignKey(c => c.IdentificationTypeId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
