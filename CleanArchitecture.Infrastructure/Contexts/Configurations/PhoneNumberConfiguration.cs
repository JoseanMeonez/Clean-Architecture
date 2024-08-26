using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
	public void Configure(EntityTypeBuilder<PhoneNumber> builder)
	{
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
	}
}
