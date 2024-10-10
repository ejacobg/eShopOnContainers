using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Api.Infrastructure;

// During design time, the web host is not properly configured, so we set the connection string here.
public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    public CatalogContext CreateDbContext(string[] args)
    {
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
            .UseSqlServer("Server=(localdb)\\eShopOnContainers;Integrated Security=true;Database=Catalog;TrustServerCertificate=true"); // needs to be changed to match what's in appsettings
        // TODO: Find a better way to get the connection string.

        return new CatalogContext(optionsBuilder.Options);
    }
}
