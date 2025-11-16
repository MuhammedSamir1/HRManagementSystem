namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public sealed record ViewBonusByIdViewModel(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid);
}


