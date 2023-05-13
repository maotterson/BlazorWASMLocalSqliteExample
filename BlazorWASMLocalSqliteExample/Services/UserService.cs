using BlazorWASMLocalSqliteExample.Models;

namespace BlazorWASMLocalSqliteExample.Services;

public class UserService
{
    
    public async Task<User> GetSampleUserAsync()
    {
        var readings = new List<BloodPressureReading>();
        return new User { Guid = Guid.NewGuid(), BloodPressureReadings = readings, Name = "John Doe" };
    }
}
