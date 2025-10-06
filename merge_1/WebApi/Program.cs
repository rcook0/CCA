using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Api;

var builder = WebApplication.CreateBuilder(args);

// Postgres
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Hardening
builder.AddMyccaHardening();

var app = builder.Build();

app.UseMyccaHardening();

// v2 generalized + v1 shims
app.MapV2();
app.MapV1Adapters();

// Baseline routes
app.MapGet("/", () => "MyCCA Modernized (NET 8)");
app.MapGet("/users", async (AppDbContext db) => await db.Users.ToListAsync());

app.Run();
