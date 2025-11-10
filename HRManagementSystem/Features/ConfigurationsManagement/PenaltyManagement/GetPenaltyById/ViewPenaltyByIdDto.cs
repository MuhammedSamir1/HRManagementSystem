namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById
{
    public sealed record ViewPenaltyByIdDto(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime PenaltyDate,
        string? Reason,
        PenaltyStatus Status,
        int? EmployeeId);
}
