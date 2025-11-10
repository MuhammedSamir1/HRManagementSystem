namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetAllSalaryItems
{
    public sealed record ViewSalaryItemDto(
        int Id,
        string Name,
        string? Description,
        decimal Amount,
        PayrollItemType ItemType,
        bool IsFixed,
        bool IsRecurring,
        int? EmployeeId);
}
