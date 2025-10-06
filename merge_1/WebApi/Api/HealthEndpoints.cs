using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api;

public static class HealthEndpoints
{
    public static IServiceCollection AddMyccaHealth(this IServiceCollection services)
    {
        services.AddHealthChecks().AddCheck("self", () => HealthCheckResult.Healthy());
        return services;
    }

    public static IEndpointRouteBuilder MapMyccaHealth(this IEndpointRouteBuilder app)
    {
        app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));
        app.MapHealthChecks("/readyz");
        return app;
    }
}
