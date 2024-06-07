namespace EventBus.Events;

// `in` allows all types derived from TIntegrationEvent to be handled with the same handler.
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in-generic-modifier
public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}

public interface IIntegrationEventHandler { }
