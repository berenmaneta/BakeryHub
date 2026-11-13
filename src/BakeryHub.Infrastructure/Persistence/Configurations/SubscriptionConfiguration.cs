using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne<User>().WithMany().HasForeignKey(s => s.CustomerUserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<BakeryProfile>().WithMany().HasForeignKey(s => s.BakeryProfileId).OnDelete(DeleteBehavior.Restrict);
    }
}