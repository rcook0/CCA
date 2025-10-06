using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

namespace Api;

public static class RateLimitingExtensions
{
    public static IServiceCollection AddMyccaRateLimiting(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = 429;
            options.AddFixedWindowLimiter("fixed", opt =>
            {
                opt.PermitLimit = 100;
                opt.Window = TimeSpan.FromMinutes(1);
                opt.QueueLimit = 0;
                opt.AutoReplenishment = true;
            });
        });
        return services;
    }

    public static IApplicationBuilder UseMyccaRateLimiting(this IApplicationBuilder app)
        => app.UseRateLimiter();
}
