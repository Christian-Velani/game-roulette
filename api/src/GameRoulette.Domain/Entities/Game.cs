using System.ComponentModel;

namespace GameRoulette.Domain.Entities;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? SteamAppId { get; set; }
    public List<Category> Category { get; set; } = new();
}