using BlazorWASMLocalSqliteExample.Common.Exceptions;
using BlazorWASMLocalSqliteExample.Data;
using BlazorWASMLocalSqliteExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASMLocalSqliteExample.Services;

public class UserService : IUserService
{
    private readonly BPDbContext _dbContext;
    public UserService(BPDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserByGuidAsync(Guid guid)
    {
        var user = await _dbContext.Users
            .Include(u => u.BloodPressureReadings)
            .FirstOrDefaultAsync(u => u.Guid == guid);
        if (user == null)
        {
            throw new UserNotFoundException(guid);
        }
        return user;
    }
    
}
