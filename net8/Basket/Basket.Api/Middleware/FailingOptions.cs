namespace Basket.Api.Middleware;

public class FailingOptions
{
    public string ConfigPath = "/Failing";
    public List<string> EndpointPaths { get; set; } = [];

    public List<string> NotFilteredPaths { get; set; } = [];
}
