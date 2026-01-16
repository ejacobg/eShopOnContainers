namespace Basket.Api.Middleware;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseFailingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseFailingMiddleware(null);
    }

    public static IApplicationBuilder UseFailingMiddleware(this IApplicationBuilder builder, Action<FailingOptions> action)
    {
        var options = new FailingOptions();
        action?.Invoke(options);
        builder.UseMiddleware<FailingMiddleware>(options);
        return builder;
    }
}
