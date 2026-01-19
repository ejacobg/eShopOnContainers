using System.ComponentModel.DataAnnotations;

using Catalog.Api.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Entities;

[EntityTypeConfiguration(typeof(CatalogBrandConfiguration))]
public class CatalogBrand
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Brand { get; set; }
}
