namespace HRManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetShiftById
{
    public sealed record ViewShiftByIdViewModel
    {
        public int Id { get; private set; }
        public string Name { get; init; } = default!;
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
    }
}

