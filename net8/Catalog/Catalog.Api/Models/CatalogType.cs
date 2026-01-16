using Catalog.Api.Models.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Models;

[EntityTypeConfiguration(typeof(CatalogTypeConfiguration))]
public class CatalogType
{
    public int Id { get; set; }

    public string Type { get; set; }
}
