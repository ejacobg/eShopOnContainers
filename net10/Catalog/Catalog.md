# Catalog

A record of the features that this current version of the catalog maintains.

## Entities

### CatalogBrand

Just an ID and name.

### CatalogType

Also an ID and name.

### CatalogItem

Typical fields - ID, name, description, price.

Catalog items have exactly 1 brand and exactly 1 type.

Contains some other metadata fields: picture file name, available stock, restock threshold, max stock threshold, whether it's on reorder status or not.
