using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Gammon.Db;

public sealed class GamesContext : DbContext
{
    public GamesContext(string connString) : base(new DbContextOptionsBuilder().UseSqlite(connString).Options)
    {
    }

    public GamesContext(DbContextOptions<GamesContext> ctx)
        : base(ctx)
    {
    }

    public GamesContext(DbContextOptions ctx)
        : base(ctx)
    {
    }

    public DbSet<Game> Games { get; set; }

    public static GamesContext AutoCreate()
    {
        Directory.CreateDirectory(ConfigConsts.ConfigPath);

        var raw = new GamesContext(ConfigConsts.ConnectionString);

        raw.Database.EnsureCreated();

        return raw;
    }
}