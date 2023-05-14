using BlazorWASMLocalSqliteExample.Models;

namespace BlazorWASMLocalSqliteExample.Data;

public class BPDataSeeder
{
    private readonly BPDbContext _context;
    public BPDataSeeder(BPDbContext context)
    {
        _context = context;
    }
    public void Seed()
    {
        try
        {
            _context.Database.EnsureCreated();
            if (_context.Users.Any())
            {
                return;
            }

            SeedUsers();
            foreach (var user in _context.Users.Local)
            {
                SeedBloodPressureReadingsFor(user);
            }
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void SeedUsers()
    {
        var user1 = new User { Name = "John Doe", Guid = Guid.NewGuid() };
        var user2 = new User { Name = "Jane Smith", Guid = Guid.NewGuid() };
        var user3 = new User { Name = "Bob Johnson", Guid = Guid.NewGuid() };

        // Add the user entities to the DbSet
        _context.Users.AddRange(user1, user2, user3);

    }
    public void SeedBloodPressureReadingsFor(User user)
    {
        var random = new Random();
        for(int i = 0; i < 10; i++)
        {
            var systolic = random.Next(100, 140);
            var diastolic = random.Next(70, 90);
            var pulse = random.Next(50, 65);
            var reading = new BloodPressureReading
            {
                Guid = Guid.NewGuid(),
                User = user,
                UserId = user.Guid,
                Systolic = systolic,
                Diastolic = diastolic,
                Pulse = pulse,
                DateTimeOffset = DateTimeOffset.Now.AddDays(-i)
            };
            _context.Readings.Add(reading);
        }
    }
}