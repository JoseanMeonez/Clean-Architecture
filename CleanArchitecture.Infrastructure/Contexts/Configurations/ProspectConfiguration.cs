using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class ProspectConfiguration : IEntityTypeConfiguration<Prospect>
{
	public void Configure(EntityTypeBuilder<Prospect> builder)
	{
		builder.ToTable(nameof(Prospect));

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(p => p.LastName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(p => p.MarriedLastName)
			.HasMaxLength(100);

		builder.Property(p => p.Address)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(p => p.GenderId)
			.IsRequired();

		builder.Property(p => p.CountryId)
			.IsRequired();

		builder.Property(p => p.IdentificationTypeId)
			.IsRequired();

		builder.Property(p => p.NeighborhoodId)
			.IsRequired(false);

		builder.Property(p => p.IdentificationValue)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(p => p.PhoneNumber)
			.IsRequired()
			.HasMaxLength(15);

		builder.Property(p => p.PhoneNumberDesc)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(p => p.Email)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(p => p.EmailDesc)
			.IsRequired()
			.HasMaxLength(250);

		// Relationships
		builder.HasOne(p => p.Gender)
			.WithMany()
			.HasForeignKey(p => p.GenderId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(p => p.Country)
			.WithMany()
			.HasForeignKey(p => p.CountryId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(p => p.IdentificationType)
			.WithMany()
			.HasForeignKey(p => p.IdentificationTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(p => p.Neighborhood)
			.WithMany()
			.HasForeignKey(p => p.NeighborhoodId)
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
