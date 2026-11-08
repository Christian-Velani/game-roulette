using GameRoulette.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameRoulette.Infrastructure.Persistence.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(g => g.Name).IsRequired().HasMaxLength(200);

        builder.HasIndex(g => g.SteamAppId).IsUnique();
    }
}