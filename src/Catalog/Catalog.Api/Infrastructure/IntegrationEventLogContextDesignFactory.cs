using IntegrationEventLog;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Api.Infrastructure;

// During design time, the web host is not properly configured, so we set the connection string here.
public class IntegrationEventLogContextDesignFactory : IDesignTimeDbContextFactory<IntegrationEventLogContext>
{
    public IntegrationEventLogContext CreateDbContext(string[] args)
    {
        // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        var optionsBuilder = new DbContextOptionsBuilder<IntegrationEventLogContext>()
            .UseSqlServer("Server=(localdb)\\eShopOnContainers;Integrated Security=true;Database=Catalog;TrustServerCertificate=true", options => options.MigrationsAssembly("Catalog.Api"));
        // needs to be changed to match what's in appsettings

        // Your target project 'Catalog.Api' doesn't match your migrations assembly 'IntegrationEventLog'. Either change your target project or change your migrations assembly.
        // Change your migrations assembly by using DbContextOptionsBuilder.E.g.options.UseSqlServer(connection, b => b.MigrationsAssembly("Catalog.Api")). By default, the migrations assembly is the assembly containing the DbContext.
        // Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.

        // Sidenote: options.MigrationsAssembly(GetType().Assembly.GetName().Name) seems to write the snapshot file to the /Migrations directory, not the one specified in -OutputDir.

        return new IntegrationEventLogContext(optionsBuilder.Options);
    }
}
