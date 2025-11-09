namespace HRManagementSystem.Features.ShiftManagement.GetAllShifts
{
    public sealed record ViewShiftViewModel
    {
        public int Id { get; private set; }
        public string Name { get; init; } = default!;
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
    }
}

