using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(u => u.Id);

		builder.Property(u => u.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(u => u.LastName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(u => u.UserName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(u => u.GenderId)
			.IsRequired();

		builder.Property(u => u.PasswordHash)
			.IsRequired()
			.HasColumnType("varbinary(max)");

		builder.Property(u => u.PasswordSalt)
			.IsRequired()
			.HasColumnType("varbinary(max)");

		// Relationships
		builder.HasOne(u => u.Gender)
			.WithMany()
			.HasForeignKey(u => u.GenderId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
