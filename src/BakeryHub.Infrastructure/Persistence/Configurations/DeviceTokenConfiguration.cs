using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class DeviceTokenConfiguration : IEntityTypeConfiguration<DeviceToken>
{
    public void Configure(EntityTypeBuilder<DeviceToken> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Token).IsRequired().HasMaxLength(255);
        builder.Property(d => d.Platform).IsRequired().HasMaxLength(50);

        builder.HasOne<User>().WithMany().HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}