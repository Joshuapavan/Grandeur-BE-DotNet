using System;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
                    .HasIndex(user => user.Email)
                    .IsUnique();

        modelBuilder.Entity<User>()
                    .HasMany(user => user.Cars)
                    .WithOne(car => car.User)
                    .HasForeignKey(car => car.UserId);

        modelBuilder.Entity<Car>()
                    .HasOne(car => car.Photo)
                    .WithOne(photo => photo.Car)
                    .HasForeignKey<Photo>(photo => photo.CarId);
    }
}
