using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Api;

public static class V2Endpoints
{
    public static IEndpointRouteBuilder MapV2(this IEndpointRouteBuilder app)
    {
        var g = app.MapGroup("/api/v2");

        g.MapGet("/users", async (AppDbContext db, string? role) =>
        {
            var q = db.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(role))
            {
                var wanted = role.ToLowerInvariant();
                q = q.Where(u =>
                    (wanted == "participant" && u.Role == "Student") ||
                    (wanted == "advisor"     && u.Role == "Counselor") ||
                    (wanted == "admin"       && u.Role == "Admin"));
            }
            return Results.Ok(await q.ToListAsync());
        });

        g.MapGet("/participants", async (AppDbContext db) =>
            Results.Ok(await db.Users.Where(u => u.Role == "Student").ToListAsync()));

        g.MapGet("/advisors", async (AppDbContext db) =>
            Results.Ok(await db.Users.Where(u => u.Role == "Counselor").ToListAsync()));

        return app;
    }

    public static IEndpointRouteBuilder MapV1Adapters(this IEndpointRouteBuilder app)
    {
        var g = app.MapGroup("/api/v1");

        g.MapGet("/students", async (AppDbContext db) =>
            Results.Ok(await db.Users.Where(u => u.Role == "Student").ToListAsync()))
         .AddEndpointFilter(async (ctx, next) =>
         {
             var result = await next(ctx);
             ctx.HttpContext.Response.Headers.Append("Deprecation", "true");
             ctx.HttpContext.Response.Headers.Append("Link", "</api/v2/participants>; rel="successor-version"");
             return result;
         });

        g.MapGet("/counselors", async (AppDbContext db) =>
            Results.Ok(await db.Users.Where(u => u.Role == "Counselor").ToListAsync()))
         .AddEndpointFilter(async (ctx, next) =>
         {
             var result = await next(ctx);
             ctx.HttpContext.Response.Headers.Append("Deprecation", "true");
             ctx.HttpContext.Response.Headers.Append("Link", "</api/v2/advisors>; rel="successor-version"");
             return result;
         });

        return app;
    }
}
