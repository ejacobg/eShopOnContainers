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

I saw one example using `MultipleActiveResultSets=true` on the connection string, but in this case it starts to throw warnings when applying migrations.
> Savepoints are disabled because Multiple Active Result Sets (MARS) is enabled. If 'SaveChanges' fails, then the transaction cannot be automatically rolled back to a known clean state. Instead, the transaction should be rolled back by the application before retrying 'SaveChanges'. See https://go.microsoft.com/fwlink/?linkid=2149338 for more information and examples. To identify the code which triggers this warning, call 'ConfigureWarnings(w => w.Throw(SqlServerEventId.SavepointsDisabledBecauseOfMARS))'.

I'm going to remove MARS for now, especially since it wasn't present in the original implementation.

## Controllers

Swagger currently isn't set up right now. Going straight to the endpoints works, but all other routes will end up 404-ing.

### Catalog

```http
###
GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]

###
GET api/v1/[controller]/items[?ids=1,2,3,...]
```
