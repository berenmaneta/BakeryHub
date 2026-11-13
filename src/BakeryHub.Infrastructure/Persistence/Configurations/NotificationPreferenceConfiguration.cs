using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class NotificationPreferenceConfiguration : IEntityTypeConfiguration<NotificationPreference>
{
    public void Configure(EntityTypeBuilder<NotificationPreference> builder)
    {
        builder.HasKey(np => np.Id);

        builder.HasOne<User>().WithMany().HasForeignKey(np => np.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<BakeryProfile>().WithMany().HasForeignKey(np => np.BakeryProfileId).OnDelete(DeleteBehavior.Restrict);
    }
}