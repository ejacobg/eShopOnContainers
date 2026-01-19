using Catalog.Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Data;

public class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options)
{
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    // Usage of the [EntityTypeConfiguration] attribute obviates the need for overriding OnModelCreating
    // https://learn.microsoft.com/en-us/ef/core/modeling/#using-entitytypeconfigurationattribute-on-entity-types
}
