# Catalog

A record of the features that this current version of the catalog maintains.

## Program.cs

Will be using the minimal hosting model instead of a `Startup` class like the original and .NET 8 versions use. 

## Entities

Added some data annotations for clarity when looking at the classes, but in practice they're redundant since they are applied by the `IEntityTypeConfiguration` classes. 

I'd normally make all fields `required`, but I'm having trouble enforcing this. I'm gonna stick with non-required fields only for those managed by the framework (namely PKs and navigation properties). See also [Working with Nullable Reference Types](https://learn.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types).

### CatalogBrand

Just an ID and name.

### CatalogType

Also an ID and name.

### CatalogItem

Typical fields - ID, name, description, price.

Catalog items have exactly 1 brand and exactly 1 type.

Contains some other metadata fields: picture file name, available stock, restock threshold, max stock threshold, whether it's on reorder status or not.

Provides methods for adding to/removing from the stock.

## Data

Omitting the `CatalogContextDesignFactory` for now. Will add it back later on if/when it's actually needed.
