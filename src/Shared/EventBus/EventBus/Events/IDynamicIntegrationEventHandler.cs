namespace EventBus.Events;

// ChatGPT (GPT-4): Dynamic Handlers: Ideal for external event sources, such as webhooks or third-party APIs, where the event structures are not known at development time or can change frequently.
public interface IDynamicIntegrationEventHandler
{
    Task Handle(dynamic eventData);
}
