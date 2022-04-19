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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source=db/assistant.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChanifyChannel>().ToTable("chanify_channel")
            .Property(e=>e.Type).HasConversion<string>();
    }
}