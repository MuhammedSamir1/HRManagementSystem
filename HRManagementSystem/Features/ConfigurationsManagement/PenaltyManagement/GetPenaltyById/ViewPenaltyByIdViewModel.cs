namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById
{
    public sealed record ViewPenaltyByIdViewModel(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status);
}


