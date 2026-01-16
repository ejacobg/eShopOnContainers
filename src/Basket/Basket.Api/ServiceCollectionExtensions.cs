using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Basket.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        var hcBuilder = services.AddHealthChecks();

        hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

        hcBuilder
            .AddRedis(
                configuration["ConnectionString"],
                name: "redis-check",
                tags: ["redis"]);

        if (configuration.GetValue<bool>("AzureServiceBusEnabled"))
        {
            hcBuilder
                .AddAzureServiceBusTopic(
                    configuration["EventBusConnection"],
                    topicName: "eshop_event_bus",
                    name: "basket-servicebus-check",
                    tags: ["servicebus"]);
        }
        else
        {
            hcBuilder
                .AddRabbitMQ(
                    $"amqp://{configuration["EventBusConnection"]}",
                    name: "basket-rabbitmqbus-check",
                    tags: ["rabbitmqbus"]);
        }

        return services;
    }
}
