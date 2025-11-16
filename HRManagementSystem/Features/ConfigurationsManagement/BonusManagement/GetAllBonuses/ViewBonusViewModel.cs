namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses
{
    public sealed record ViewBonusViewModel(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid);
}


