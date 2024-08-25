using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class EmailConfiguration : IEntityTypeConfiguration<Email>
{
	public void Configure(EntityTypeBuilder<Email> entity)
	{
		entity.ToTable(nameof(Email));

		entity.HasKey(e => e.Id);

		entity.Property(e => e.Description)
			.HasMaxLength(50)
			.IsUnicode(false);

		entity.Property(e => e.EmailName)
			.HasMaxLength(100)
			.IsUnicode(false);

		entity.HasOne(d => d.Customer).WithMany(p => p.Emails)
			.HasForeignKey(d => d.CustomerId)
			.OnDelete(DeleteBehavior.ClientSetNull)
			.HasConstraintName($"FK_{nameof(Email)}_{nameof(Customer)}");
	}
}
