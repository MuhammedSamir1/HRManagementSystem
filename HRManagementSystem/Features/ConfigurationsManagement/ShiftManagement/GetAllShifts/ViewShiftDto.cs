namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts
{
    public sealed record ViewShiftDto
    {
        public int Id { get; private set; }
        public string Name { get; init; } = default!;
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
    }
}

