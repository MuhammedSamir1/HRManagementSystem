namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses
{
    public sealed record ViewBonusViewModel(
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

