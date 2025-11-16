namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetAllBonuses
{
    public sealed record ViewBonusDto(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        BonusType BonusType,
        DateTime BonusDate,
        DateTime? PaymentDate,
        bool IsPaid);
}

