using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class ProspectConfiguration : IEntityTypeConfiguration<Prospect>
{
	public void Configure(EntityTypeBuilder<Prospect> entity)
	{
		entity.ToTable(nameof(Prospect));

		entity.HasKey(p => p.Id);

		entity.Property(e => e.Address)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.Email)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.EmailDesc)
			.HasMaxLength(50)
			.IsUnicode(false);

		entity.Property(e => e.IdentificationValue)
			.HasMaxLength(50)
			.IsUnicode(false);

		entity.Property(e => e.LastName)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.MarriedLastName)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.Name)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.Property(e => e.PhoneNumber)
			.HasMaxLength(8)
			.IsUnicode(false);

		entity.Property(e => e.PhoneNumberDesc)
			.HasMaxLength(50)
			.IsUnicode(false);
	}
}
