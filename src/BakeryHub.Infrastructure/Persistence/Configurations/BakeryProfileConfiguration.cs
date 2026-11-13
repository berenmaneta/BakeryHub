using BakeryHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakeryHub.Infrastructure.Persistence.Configurations;

public class BakeryProfileConfiguration : IEntityTypeConfiguration<BakeryProfile>
{
    public void Configure(EntityTypeBuilder<BakeryProfile> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.TradeName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Description)
            .HasMaxLength(500);

        builder.Property(b => b.Phone)
            .HasMaxLength(20);

        builder.Property(b => b.Address)
            .HasMaxLength(500);

        builder.Property(b => b.LogoUrl)
            .HasMaxLength(500);

        // Mapeamento da Chave Estrangeira (Restringe a deleção em cascata para evitar acidentes)
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}