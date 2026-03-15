using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationType>
{
	public void Configure(EntityTypeBuilder<IdentificationType> builder)
	{
		builder.ToTable(nameof(IdentificationType));

		builder.HasKey(it => it.Id);

		builder.Property(it => it.Name)
			.IsRequired()
			.HasMaxLength(50);

		// Relationships
		builder.HasMany(it => it.Customers)
			.WithOne(c => c.IdentificationType)
			.HasForeignKey(c => c.IdentificationTypeId)
			.OnDelete(DeleteBehavior.Restrict);

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
