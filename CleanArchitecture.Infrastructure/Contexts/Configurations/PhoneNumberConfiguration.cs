using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
	public void Configure(EntityTypeBuilder<PhoneNumber> entity)
	{
		entity.ToTable(nameof(PhoneNumber));

		entity.HasKey(e => e.Id);

		entity.Property(e => e.Description)
			.HasMaxLength(50)
			.IsUnicode(false);

		entity.Property(e => e.Number)
			.HasMaxLength(8)
			.IsUnicode(false);

		entity.HasOne(d => d.Customer).WithMany(p => p.PhoneNumbers)
			.HasForeignKey(d => d.CustomerId)
			.OnDelete(DeleteBehavior.ClientSetNull);
	}
}
