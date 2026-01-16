# IntegrationEventLog

### [Designing atomicity and resiliency when publishing to the event bus](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/subscribe-events#designing-atomicity-and-resiliency-when-publishing-to-the-event-bus)

In order to ensure that integration events get properly published, the application writes to to an event log table in the same transaction as the operation that triggers the event. This way, the event log is guaranteed to be written if the operation is successful.

![Integration event log](../../img/atomicity-publish-event-bus.png)
