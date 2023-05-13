using BlazorWASMLocalSqliteExample.Models;

namespace BlazorWASMLocalSqliteExample.Services;

public interface IUserService
{
    public Task<User> GetUserByGuidAsync(Guid guid);
}
