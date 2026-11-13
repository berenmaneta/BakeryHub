using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class BakeryApplicationConfiguration : IEntityTypeConfiguration<BakeryApplication>
{
    public void Configure(EntityTypeBuilder<BakeryApplication> builder)
    {
        builder.HasKey(ba => ba.Id);
        builder.Property(ba => ba.TradeName).IsRequired().HasMaxLength(200);
        builder.Property(ba => ba.DocumentNumber).IsRequired().HasMaxLength(20);
        builder.Property(ba => ba.Phone).HasMaxLength(20);
        builder.Property(ba => ba.Address).HasMaxLength(500);
        builder.Property(ba => ba.Description).HasMaxLength(500);
        builder.HasOne<User>().WithMany().HasForeignKey(ba => ba.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}