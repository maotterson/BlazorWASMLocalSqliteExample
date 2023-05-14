using BlazorWASMLocalSqliteExample.Common.Exceptions;
using BlazorWASMLocalSqliteExample.Data;
using BlazorWASMLocalSqliteExample.Models;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace BlazorWASMLocalSqliteExample.Services;

public class UserService : IUserService
{
    private readonly ISqliteWasmDbContextFactory<BPDbContext> _dbFactory;

    public UserService(ISqliteWasmDbContextFactory<BPDbContext> factory)
    {
        _dbFactory = factory;
    }

    public async Task CreateUserAsync(string name)
    {
        using var context = await _dbFactory.CreateDbContextAsync();
        context.Add(new User
        {
            Guid = Guid.NewGuid(),
            Name = name,
            BloodPressureReadings = new List<BloodPressureReading>()
        });
        context.SaveChanges();
        return;
    }
    public async Task<User> GetUserByGuidAsync(Guid guid)
    {
        using var context = await _dbFactory.CreateDbContextAsync();
        var user = await context.Users
            .Include(u => u.BloodPressureReadings)
            .FirstOrDefaultAsync(u => u.Guid == guid);
        if (user == null)
        {
            throw new UserNotFoundException(guid);
        }
        return user;
    }
    
}
