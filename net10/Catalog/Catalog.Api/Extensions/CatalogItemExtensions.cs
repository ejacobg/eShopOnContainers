using Catalog.Api.Entities;

namespace Catalog.Api.Extensions;

public static class CatalogItemExtensions
{
    // can't this just be a regular method?
    public static void FillProductUrl(this CatalogItem item, string picBaseUrl, bool azureStorageEnabled)
    {
        item.PictureUri = azureStorageEnabled
            ? picBaseUrl + item.PictureFileName
            : picBaseUrl.Replace("[0]", item.Id.ToString());
    }
}
