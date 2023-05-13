namespace BlazorWASMLocalSqliteExample.Models;

public class BloodPressureReading
{
    public Guid Guid { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public DateTimeOffset DateTimeOffset { get; set; } = default!;
    public int Systolic { get; set; } = default!;
    public int Diastolic { get; set; } = default!;
    public int Pulse { get; set; } = default!;
}
