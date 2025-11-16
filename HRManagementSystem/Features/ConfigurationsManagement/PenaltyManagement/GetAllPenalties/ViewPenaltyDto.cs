namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetAllPenalties
{
    public sealed record ViewPenaltyDto(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status);
}

