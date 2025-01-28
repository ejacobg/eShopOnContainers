# Basket

### [Challenge #3: How to achieve consistency across multiple microservices](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/distributed-data-management#challenge-3-how-to-achieve-consistency-across-multiple-microservices)

> The Basket microservice manages temporal data about product items that users are adding to their shopping baskets, which includes the price of the items at the time they were added to the basket. When a product's price is updated in the catalog, that price should also be updated in the active baskets that hold that same product, plus the system should probably warn the user saying that a particular item's price has changed since they added it to their basket.

> The Catalog microservice shouldn't update the Basket table directly, because the Basket table is owned by the Basket microservice. To make an update to the Basket microservice, the Catalog microservice [uses] eventual consistency based on asynchronous communication such as integration events (message and event-based communication).

### [External versus internal architecture and design patterns](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/microservice-application-design#external-versus-internal-architecture-and-design-patterns)

> For instance, in our eShopOnContainers sample, the catalog, basket, and user profile microservices are simple (basically, CRUD subsystems). Therefore, their internal architecture and design is straightforward.

## Notes

Features a Redis cache for storing basket data.
