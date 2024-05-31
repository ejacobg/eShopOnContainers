using Catalog.Api.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Api.Infrastructure;

// Your DbContext does not need to be sealed, but sealing is best practice to do so for classes not designed to be inherited from.
// https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
public class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options)
{
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Redundant since adding a DbSet will automatically add the entity to the model.
        // https://learn.microsoft.com/en-us/ef/core/modeling/#using-entitytypeconfigurationattribute-on-entity-types
        // builder.Entity<CatalogBrand>();
        // builder.Entity<CatalogItem>();
        // builder.Entity<CatalogType>();
    }
}

public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    public CatalogContext CreateDbContext(string[] args)
    {
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
            .UseSqlServer("Server=.;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;Integrated Security=true");

        return new CatalogContext(optionsBuilder.Options);
    }
}
