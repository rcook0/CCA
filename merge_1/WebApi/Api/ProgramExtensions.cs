using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

public static class ProgramExtensions
{
    public static void AddMyccaHardening(this WebApplicationBuilder builder)
    {
        builder.Services.AddMyccaHealth();
        builder.Services.AddMyccaRateLimiting();
    }

    public static void UseMyccaHardening(this WebApplication app)
    {
        app.UseMyccaSecurityHeaders();
        app.UseMyccaRateLimiting();
        app.MapMyccaHealth();
    }
}
