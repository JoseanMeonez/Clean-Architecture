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
