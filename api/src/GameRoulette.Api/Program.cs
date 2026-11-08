using GameRoulette.Infrastructure;
using GameRoulette.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Connection string 'Default' not found.");

builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();
builder.Services.AddHealthChecks()
    .AddDbContextCheck<AppDbContext>("database", customTestQuery: async (db, cancellationToken) =>
    {
        await db.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken);
        return true;
    });

var app = builder.Build();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();