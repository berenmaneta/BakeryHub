using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryHub.Infrastructure.Persistence;

public class BakeryHubDbContext : DbContext
{
    public BakeryHubDbContext(DbContextOptions<BakeryHubDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<BakeryApplication> BakeryApplications => Set<BakeryApplication>();
    public DbSet<BakeryProfile> BakeryProfiles => Set<BakeryProfile>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Batch> Batches => Set<Batch>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<NotificationPreference> NotificationPreferences => Set<NotificationPreference>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<DeviceToken> DeviceTokens => Set<DeviceToken>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Isso varre a nossa camada de infraestrutura procurando classes que implementam 
        // IEntityTypeConfiguration e aplica as regras de banco (tamanhos, chaves, índices) automaticamente.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BakeryHubDbContext).Assembly);
    }
}