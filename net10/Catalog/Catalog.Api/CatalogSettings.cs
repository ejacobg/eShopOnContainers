namespace Catalog.Api;

public class CatalogSettings
{
    public required string PicBaseUrl { get; set; }

    public required string EventBusConnection { get; set; }

    public required bool UseCustomizationData { get; set; }

    public required bool AzureStorageEnabled { get; set; }
}
