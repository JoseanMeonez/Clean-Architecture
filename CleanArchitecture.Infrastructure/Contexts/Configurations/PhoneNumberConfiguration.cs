using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
	public void Configure(EntityTypeBuilder<PhoneNumber> builder)
	{
		builder.ToTable(nameof(PhoneNumber));

		builder.HasKey(pn => pn.Id);

		builder.Property(pn => pn.Description)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(pn => pn.Number)
			.IsRequired()
			.HasMaxLength(15);

		builder.Property(pn => pn.CustomerId)
			.IsRequired();

		// Relationships
		builder.HasOne(pn => pn.Customer)
			.WithMany(c => c.PhoneNumbers)
			.HasForeignKey(pn => pn.CustomerId)
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
