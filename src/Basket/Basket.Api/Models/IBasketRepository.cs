namespace Basket.Api.Models;

public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string customerId);

    // TODO GetUsersAsync()?
    IEnumerable<string> GetUsers();
    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string id);
}
