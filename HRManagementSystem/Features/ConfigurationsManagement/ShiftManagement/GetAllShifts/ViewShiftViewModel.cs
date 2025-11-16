namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts
{
    public sealed record ViewShiftViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; init; } = default!;
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
    }
}


