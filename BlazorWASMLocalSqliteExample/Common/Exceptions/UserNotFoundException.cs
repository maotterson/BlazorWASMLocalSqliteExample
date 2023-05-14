namespace BlazorWASMLocalSqliteExample.Common.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid guid) : base($"User {guid} not found.")
    {
    }
}