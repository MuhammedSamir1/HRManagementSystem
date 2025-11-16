namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems
{
    public sealed record ViewSalaryItemViewModel(
        Guid Id,
        string Name,
        string? Description,
        decimal Amount,
        PayrollItemType ItemType,
        bool IsFixed,
        bool IsRecurring);
}


