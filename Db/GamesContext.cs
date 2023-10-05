using Microsoft.EntityFrameworkCore;

namespace Gammon.Db;

public sealed class GamesContext : DbContext
{
    public GamesContext(DbContextOptions<GamesContext> ctx)
        : base(ctx)
    {
    }

    public GamesContext(DbContextOptions ctx)
        : base(ctx)
    {
    }

    public DbSet<Game> Games { get; set; }
}