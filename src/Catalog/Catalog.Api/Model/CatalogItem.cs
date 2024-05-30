namespace Catalog.Api.Model;

public class CatalogItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureFileName { get; set; }

    public string PictureUri { get; set; }

    public int CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; }

    public int CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; }

    // Current stock.
    public int AvailableStock { get; set; }

    // Reorder when below this threshold.
    public int RestockThreshold { get; set; }

    // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses).
    public int MaxStockThreshold { get; set; }

    /// <summary>
    /// True if item is on reorder.
    /// </summary>
    public bool OnReorder { get; set; }

    public CatalogItem() { }

    /// <summary>
    /// Removes up to the desired quantity of items from stock. If there is less stock than requested, the method will remove whatever is available.
    /// 
    /// Users should confirm whether the requested number of items has been removed or not.
    /// 
    /// It is invalid to pass in a negative number. 
    /// </summary>
    /// <param name="quantityDesired"></param>
    /// <returns>int: Returns the number actually removed from stock. </returns>
    public int RemoveStock(int quantityDesired)
    {
        if (AvailableStock == 0)
        {
            throw new InvalidOperationException($"Empty stock, product item {Name} is sold out.");
        }

        if (quantityDesired <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantityDesired), "Item units desired should be less than zero.");
        }

        int removed = Math.Min(quantityDesired, AvailableStock);

        AvailableStock -= removed;

        return removed;
    }

    /// <summary>
    /// Increments the quantity of a particular item in inventory.
    /// <param name="quantity"></param>
    /// <returns>int: Returns the quantity that has been added to stock</returns>
    /// </summary>
    public int AddStock(int quantity)
    {
        int original = AvailableStock;

        // The quantity that the client is trying to add to stock is greater than what can be physically accommodated in the Warehouse
        if ((AvailableStock + quantity) > MaxStockThreshold)
        {
            // For now, this method only adds new units up maximum stock threshold. In an expanded version of this application, we
            //could include tracking for the remaining units and store information about overstock elsewhere. 
            AvailableStock += (MaxStockThreshold - AvailableStock);
        }
        else
        {
            AvailableStock += quantity;
        }

        OnReorder = false;

        return AvailableStock - original;
    }
}
