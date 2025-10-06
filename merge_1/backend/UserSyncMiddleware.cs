using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Middleware;
public class UserSyncMiddleware
{
    private readonly RequestDelegate _next;
    public UserSyncMiddleware(RequestDelegate next) { _next = next; }
    public async Task InvokeAsync(HttpContext context, AppDbContext db)
    {
        if (context.User?.Identity?.IsAuthenticated == true)
        {
            var email = context.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? "unknown";
            var roles = context.User.Claims.Where(c => c.Type == "role" || c.Type == "roles").Select(c => c.Value).ToList();
            var priority = new[] { "admin", "counselor", "student" };
            var assignedRole = priority.FirstOrDefault(r => roles.Contains(r)) ?? "student";
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                user = new User { Id = Guid.NewGuid(), Email = email, Role = assignedRole, LastSynced = DateTime.UtcNow };
                db.Users.Add(user);
            }
            else { user.Role = assignedRole; user.LastSynced = DateTime.UtcNow; }
            await db.SaveChangesAsync();
        }
        await _next(context);
    }
}