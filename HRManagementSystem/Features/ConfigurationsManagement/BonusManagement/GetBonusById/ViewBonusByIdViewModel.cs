namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public sealed record ViewBonusByIdViewModel(
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

