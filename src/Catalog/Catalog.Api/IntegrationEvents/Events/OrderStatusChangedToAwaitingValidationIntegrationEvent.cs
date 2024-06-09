using Catalog.Api.IntegrationEvents.Models;

using EventBus.Events;

namespace Catalog.Api.IntegrationEvents.Events;

// Integration Events notes: 
// An Event is "something that has happened in the past", therefore its name has to be past tense
// An Integration Event is an event that can cause side effects to other microservices, Bounded-Contexts or external systems.
public record OrderStatusChangedToAwaitingValidationIntegrationEvent : IntegrationEvent
{
    public int OrderId { get; }
    public IEnumerable<OrderStockItem> OrderStockItems { get; }

    public OrderStatusChangedToAwaitingValidationIntegrationEvent(int orderId,
        IEnumerable<OrderStockItem> orderStockItems)
    {
        OrderId = orderId;
        OrderStockItems = orderStockItems;
    }
}
