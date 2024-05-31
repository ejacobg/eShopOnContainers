using Catalog.Api.Models.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Models;

// https://learn.microsoft.com/en-us/ef/core/modeling/#using-entitytypeconfigurationattribute-on-entity-types
[EntityTypeConfiguration(typeof(CatalogBrandConfiguration))]
public class CatalogBrand
{
    public int Id { get; set; }

    public string Brand { get; set; }
}
