using Catalog.Api.Data;
using Catalog.Api.Entities;
using Catalog.Api.Extensions;
using Catalog.Api.Responses;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogContext _catalogContext;
    private readonly CatalogSettings _catalogSettings;

    public CatalogController(CatalogContext catalogContext, IOptionsSnapshot<CatalogSettings> catalogSettings)
    {
        _catalogContext = catalogContext;
        _catalogSettings = catalogSettings.Value;

        _catalogContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10] => paginated response
    // OR
    // GET api/v1/[controller]/items[?ids=1,2,3,...] => IEnumerable
    // Not sure if I agree having the same action act as 2 different endpoints, but sticking with it for now since there will be dependency on it
    [HttpGet("items")]
    // Results<T> should make [ProducesResponseType] attributes redundant
    //[ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItem>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(IEnumerable<CatalogItem>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<PaginatedItemsResponse<CatalogItem>>, Ok<IEnumerable<CatalogItem>>, BadRequest<string>>> ItemsAsync(
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0,
        [FromQuery] string? ids = null)
    {
        if (!string.IsNullOrEmpty(ids))
        {
            var items = await GetItemsByIdsAsync(ids);

            if (items.Count == 0)
            {
                return TypedResults.BadRequest("0 valid ids found. Must be a comma-separated list of integers.");
            }

            return TypedResults.Ok<IEnumerable<CatalogItem>>(items);
        }

        var totalCount = await _catalogContext.CatalogItems.LongCountAsync();

        var page = await _catalogContext.CatalogItems
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItemsResponse<CatalogItem>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalCount = totalCount,
            Items = page
        });
    }

    private Task<List<CatalogItem>> GetItemsByIdsAsync(string ids)
    {
        var idSet = new HashSet<int>();

        foreach (var stringId in ids.Split(','))
        {
            if (int.TryParse(stringId, out int numId))
            {
                idSet.Add(numId);
            }
            else
            {
                return Task.FromResult<List<CatalogItem>>([]);
            }
        }

        return _catalogContext.CatalogItems.Where(ci => idSet.Contains(ci.Id)).ToListAsync();
    }

    [HttpGet("items/{id:int}")]
    public async Task<Results<Ok<CatalogItem>, NotFound, BadRequest>> ItemByIdAsync(int id)
    {
        if (id <= 0)
        {
            return TypedResults.BadRequest();
        }

        var item = await _catalogContext.CatalogItems.SingleOrDefaultAsync(item => item.Id == id);
        if (item is null)
        {
            return TypedResults.NotFound();
        }

        item.FillProductUrl(_catalogSettings.PicBaseUrl, _catalogSettings.AzureStorageEnabled);
        return TypedResults.Ok(item);
    }
}
