using System.ComponentModel.DataAnnotations;

using Catalog.Api.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Entities;

[EntityTypeConfiguration(typeof(CatalogTypeConfiguration))]
public class CatalogType
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Type { get; set; }
}
