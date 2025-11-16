namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.GetEndOfServiceById
{
    public sealed record ViewEndOfServiceByIdDto(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        DateTime ServiceStartDate,
        DateTime ServiceEndDate,
        int TotalServiceYears,
        int TotalServiceMonths,
        int TotalServiceDays,
        DateTime? PaymentDate);
}

