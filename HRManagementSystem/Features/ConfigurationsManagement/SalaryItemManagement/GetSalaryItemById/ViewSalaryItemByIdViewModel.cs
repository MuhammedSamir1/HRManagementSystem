namespace HRManagementSystem.Features.ConfigurationsManagement.SalaryItemManagement.GetSalaryItemById
{
    public sealed record ViewSalaryItemByIdViewModel(
        int Id,
        string Name,
        string? Description,
        decimal Amount,
        PayrollItemType ItemType,
        bool IsFixed,
        bool IsRecurring,
        int? EmployeeId);
}

