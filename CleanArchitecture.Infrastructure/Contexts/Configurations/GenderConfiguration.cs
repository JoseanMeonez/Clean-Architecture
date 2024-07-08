using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
	public void Configure(EntityTypeBuilder<Gender> entity)
	{
		entity.ToTable(nameof(Gender));

		entity.HasKey(e => e.Id);

		entity.Property(e => e.Name)
			.HasMaxLength(50)
			.IsUnicode(false);
	}
}
