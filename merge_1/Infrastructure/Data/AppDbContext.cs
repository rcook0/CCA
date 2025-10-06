using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<TargetEntity> TargetEntities => Set<TargetEntity>();
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Milestone> Milestones => Set<Milestone>();
    public DbSet<Decision> Decisions => Set<Decision>();
    public DbSet<Assessment> Assessments => Set<Assessment>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>()
            .HasMany(a => a.Milestones)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Application>()
            .HasMany(a => a.Decisions)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
