using BlazorWASMLocalSqliteExample.Models;

namespace BlazorWASMLocalSqliteExample.Services;

public class SampleUserService : IUserService
{
    private readonly List<User> _users = new List<User>();
    public SampleUserService()
    {
        GenerateRandomBloodPressureReadings();
    }
    private void GenerateRandomBloodPressureReadings()
    {
        var readings = new List<BloodPressureReading>();
        var sampleUser = new User { Guid = Guid.NewGuid(), BloodPressureReadings = readings, Name = "John Doe" }; for (int i = 0; i < new Random().Next(3, 10); i++)
        {
            readings.Add(GetRandomBloodPressureReadingFor(sampleUser));
        }
        _users.Add(sampleUser);
    }
    private BloodPressureReading GetRandomBloodPressureReadingFor(User user)
    {
        var random = new Random();

        return new BloodPressureReading
        {
            User = user,
            UserId = user.Guid,
            DateTimeOffset = DateTimeOffset.UtcNow,
            Guid = Guid.NewGuid(),
            Systolic = random.Next(110, 131),
            Diastolic = random.Next(70, 85),
            Pulse = random.Next(70, 85)
        };
    }
    public async Task<User> GetSampleUserAsync()
    {
        return _users.FirstOrDefault()!;
    }

    public async Task<User> GetUserByGuidAsync(Guid guid)
    {
        return _users.FirstOrDefault(x => x.Guid == guid)!;
    }
}
