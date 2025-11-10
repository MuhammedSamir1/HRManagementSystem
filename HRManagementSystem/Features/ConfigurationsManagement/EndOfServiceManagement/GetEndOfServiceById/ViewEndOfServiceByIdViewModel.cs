namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById
{
    public sealed record ViewEndOfServiceByIdViewModel(
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

