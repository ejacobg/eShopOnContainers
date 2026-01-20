namespace Catalog.Api.Responses;

public class PaginatedItemsResponse<TEntity> where TEntity : class
{
    public required int PageIndex { get; init; }
    public required int PageSize { get; init; }
    public required long TotalCount { get; init; }
    public required IEnumerable<TEntity> Items { get; init; }
}
