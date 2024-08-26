using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class ReferenceConfiguration : IEntityTypeConfiguration<Reference>
{
	public void Configure(EntityTypeBuilder<Reference> builder)
	{
		builder.ToTable(nameof(Reference));

		builder.HasKey(r => r.Id);

		builder.Property(r => r.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(r => r.PhoneNumber)
			.IsRequired()
			.HasMaxLength(15);

		builder.Property(r => r.Relationship)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(r => r.CustomerId)
			.IsRequired();

		// Relationships
		builder.HasOne(r => r.Customer)
			.WithMany(c => c.References)
			.HasForeignKey(r => r.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
