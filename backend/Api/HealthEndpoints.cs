using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Api;

public static class HealthEndpoints
{
    public static IServiceCollection AddMyccaHealth(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddCheck("db", new DelegateHealthCheck(() =>
            {
                // TODO: add real DB ping via scoped AppDbContext if desired
                return Task.FromResult(HealthCheckResult.Healthy());
            }));
        return services;
    }

    public static IEndpointRouteBuilder MapMyccaHealth(this IEndpointRouteBuilder app)
    {
        app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));
        app.MapHealthChecks("/readyz");
        return app;
    }
}