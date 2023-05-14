using BlazorWASMLocalSqliteExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASMLocalSqliteExample.Data;

public class BPDbContext : DbContext
{
    public BPDbContext(DbContextOptions<BPDbContext> options)
        : base(options)
    {
    }

    public DbSet<BloodPressureReading> Readings { get; set; }
    public DbSet<User> Users { get; set; }
}
