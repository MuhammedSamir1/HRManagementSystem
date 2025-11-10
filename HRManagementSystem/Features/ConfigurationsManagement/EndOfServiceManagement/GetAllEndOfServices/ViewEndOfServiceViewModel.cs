namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetAllEndOfServices
{
    public sealed record ViewEndOfServiceViewModel(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime ServiceStartDate,
        DateTime ServiceEndDate,
        int TotalServiceYears,
        int TotalServiceMonths,
        int TotalServiceDays,
        DateTime? PaymentDate,
        int? EmployeeId);
}

