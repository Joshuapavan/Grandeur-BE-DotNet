using System;
using Grandeur_BE_DotNet.Models.Entitiles;
using Microsoft.EntityFrameworkCore;

namespace Grandeur_BE_DotNet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
                    .HasIndex(u => u.Email)
                    .IsUnique();
    }
}
