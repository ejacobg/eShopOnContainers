using Catalog.Api.Data;
using Catalog.Api.Entities;
using Catalog.Api.Responses;

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
    // Not sure if I agree having the same action serve basically 2 different endpoints, but sticking with it for simplicity
    [HttpGet("items")]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<CatalogItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ItemsAsync(
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0,
        [FromQuery] string? ids = null)
    {
        if (!string.IsNullOrEmpty(ids))
        {
            var items = await GetItemsByIdsAsync(ids);

            if (items.Count == 0)
            {
                return BadRequest("0 valid ids found. Must be a comma-separated list of integers.");
            }

            return Ok(items);
        }

        var totalCount = await _catalogContext.CatalogItems.LongCountAsync();

        var page = await _catalogContext.CatalogItems
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return Ok(new PaginatedItemsResponse<CatalogItem>
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
}
