using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.EntityConfiguration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
        builder.Property(m => m.IsActive).IsRequired();

        builder.HasData(
            new Member(1, "Janis", "Joplin", "feminino", "janis@email.com", true),
            new Member(2, "Elvis", "Presley", "masculino", "elvis@email.com", true)
        );
    }
}
