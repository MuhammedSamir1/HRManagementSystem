namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public sealed record ViewBonusByIdDto(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid,
        int? EmployeeId);
}
