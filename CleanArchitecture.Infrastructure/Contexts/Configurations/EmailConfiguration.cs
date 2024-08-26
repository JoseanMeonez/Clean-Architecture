using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class EmailConfiguration : IEntityTypeConfiguration<Email>
{
	public void Configure(EntityTypeBuilder<Email> builder)
	{
		builder.ToTable(nameof(Email));

		builder.HasKey(e => e.Id);

		builder.Property(e => e.Description)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(e => e.EmailName)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(e => e.CustomerId)
			.IsRequired();

		// Relationships
		builder.HasOne(e => e.Customer)
			.WithMany(c => c.Emails)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
