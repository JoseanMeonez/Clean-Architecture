using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationType>
{
	public void Configure(EntityTypeBuilder<IdentificationType> entity)
	{
		entity.ToTable(nameof(IdentificationType));

		entity.Property(e => e.Name)
			.HasMaxLength(50)
			.IsUnicode(false);
	}
}
