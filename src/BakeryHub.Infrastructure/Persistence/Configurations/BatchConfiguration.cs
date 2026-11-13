using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasOne<BakeryProfile>().WithMany().HasForeignKey(b => b.BakeryProfileId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Product>().WithMany().HasForeignKey(b => b.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}