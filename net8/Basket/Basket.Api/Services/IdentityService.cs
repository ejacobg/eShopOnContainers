namespace Basket.Api.Services;

// TODO: This might be better off as some sort of helper? Doesn't really feel like a "service".
public class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    private readonly IHttpContextAccessor _context = context ?? throw new ArgumentNullException(nameof(context));

    public string GetUserIdentity()
    {
        // ? How is the user field populated?
        return _context.HttpContext.User.FindFirst("sub").Value;
    }
}
