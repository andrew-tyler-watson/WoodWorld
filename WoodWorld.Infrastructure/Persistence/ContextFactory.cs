using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WoodWorld.Infrastructure.Persistence;

public sealed class WoodWorldContextFactory
    : IDesignTimeDbContextFactory<WoodWorldContext>
{
    public WoodWorldContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var options = new DbContextOptionsBuilder<WoodWorldContext>()
            .UseSqlite(config.GetConnectionString("Default"))
            .Options;

        return new WoodWorldContext(options);
    }
}
