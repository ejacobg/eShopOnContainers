namespace Catalog.Api.IntegrationEvents.Models;

public record ConfirmedOrderStockItem
{
    public int ProductId { get; }
    public bool HasStock { get; }

    public ConfirmedOrderStockItem(int productId, bool hasStock)
    {
        ProductId = productId;
        HasStock = hasStock;
    }
}
