using Assistant2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assistant2.Dao;

public class AssistantDbContext:DbContext
{
    private readonly ILogger<AssistantDbContext> _logger;

    public AssistantDbContext(DbContextOptions<AssistantDbContext> options
    ,ILogger<AssistantDbContext> logger) : base(options)
    {
        _logger = logger;
        logger.LogInformation("db has been initialized");
    }

    public DbSet<ChanifyChannel> ChanifyChannels => Set<ChanifyChannel>();
    public DbSet<MagicSubscribe> MagicSubscribes => Set<MagicSubscribe>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source=db/assistant.db");
        _logger.LogInformation("context on configuring");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChanifyChannel>().ToTable("chanify_channel")
            .Property(e=>e.Type).HasConversion<string>();
        modelBuilder.Entity<MagicSubscribe>().ToTable("magic_subscribe")
            .Property(e => e.Type).HasConversion<string>();
    }
}