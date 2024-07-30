# EventBus

## Warning: Uncharted Territory

The e-book only goes over the event bus at a very high level. 

- [Implementing event-based communication between microservices (integration events)
](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/integration-event-based-microservice-communications)
- [Implementing an event bus with RabbitMQ for the development or test environment](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/rabbitmq-event-bus-development-test-environment)

A lot of this stuff is above my pay grade right now, and isn't really production-ready in the first place. I might do some research for better alternatives for the code here, but that's for a later time.

### Notes

- Using `IServiceScopeFactory` instead of `ILifetimeScope` inside `EventBusServiceBus`.
- Rename `IServiceBusPersisterConnection` -> `IServiceBusPersistentConnection`.

### To-Do

- [ ] Deep dive into how this all works.
- [ ] Research alternative, production-ready solutions/examples.
- [ ] Replace this code with the better solution.
