using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title).IsRequired().HasMaxLength(100);
        builder.Property(n => n.Message).IsRequired().HasMaxLength(500);

        builder.HasOne<User>().WithMany().HasForeignKey(n => n.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Batch>().WithMany().HasForeignKey(n => n.BatchId).OnDelete(DeleteBehavior.Restrict);
    }
}