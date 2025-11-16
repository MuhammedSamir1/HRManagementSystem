namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.GetAllProbationPeriods
{
    public sealed record ViewProbationPeriodViewModel
    {
        public Guid Id { get; private set; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public int DurationInDays { get; init; }
        public bool IsApproved { get; init; }
        public DateTime? ApprovalDate { get; init; }
        public ProbationPeriodStatus Status { get; init; }
    }
}


