using BlazorWASMLocalSqliteExample.Models;

namespace BlazorWASMLocalSqliteExample.Services;

public interface IUserService
{
    public Task<User> GetUserByGuidAsync(Guid guid);
    public Task CreateUserAsync(string name);
    public Task<List<User>> GetAllUsersAsync();
}
