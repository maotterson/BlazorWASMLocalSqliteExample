namespace BlazorWASMLocalSqliteExample.Models;

public class User
{
    public Guid Guid { get; set; } = default!;
    public string Name { get; set; } = default!;
    public List<BloodPressureReading> BloodPressureReadings { get; set; } = default!;

}
