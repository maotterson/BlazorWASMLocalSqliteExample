using BlazorWASMLocalSqliteExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASMLocalSqliteExample.Data;

public class BPDbContext : DbContext
{
    public DbSet<BloodPressureReading> Readings { get; set; }
    public DbSet<User> Users { get; set; }
    public BPDbContext(DbContextOptions<BPDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the primary key for the User entity
        modelBuilder.Entity<User>()
            .HasKey(u => u.Guid);

        // Configure the primary key for the BloodPressureReading entity
        modelBuilder.Entity<BloodPressureReading>()
            .HasKey(bpr => bpr.Guid);

        // Set up the one-to-many relationship between User and BloodPressureReading
        modelBuilder.Entity<User>()
            .HasMany(u => u.BloodPressureReadings)
            .WithOne(bpr => bpr.User)
            .HasForeignKey(bpr => bpr.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
