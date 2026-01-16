using IntegrationEventLog.Models;

using Microsoft.EntityFrameworkCore;

namespace IntegrationEventLog;

public class IntegrationEventLogContext(DbContextOptions<IntegrationEventLogContext> options) : DbContext(options)
{
    public DbSet<IntegrationEventLogEntry> IntegrationEventLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<IntegrationEventLogEntry>();
    }
}
