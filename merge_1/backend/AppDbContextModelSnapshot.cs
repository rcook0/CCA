using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity<Role>(b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd();
                b.Property<string>("Name").IsRequired();
                b.HasKey("Id");
                b.ToTable("Roles");
                b.HasData(
                    new Role { Id = 1, Name = "admin" },
                    new Role { Id = 2, Name = "counselor" },
                    new Role { Id = 3, Name = "student" }
                );
            });

            modelBuilder.Entity<User>(b =>
            {
                b.Property<Guid>("Id");
                b.Property<string>("Email").IsRequired();
                b.Property<int>("RoleId");
                b.Property<string>("FirstName");
                b.Property<string>("LastName");
                b.Property<DateTime>("LastSynced");
                b.HasKey("Id");
                b.HasIndex("RoleId");
                b.HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
                b.ToTable("Users");
            });
        }
    }
}