namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans
{
    public sealed record ViewLoanDto(
        int Id,
        string Title,
        string? Description,
        decimal Amount,
        decimal RemainingAmount,
        decimal MonthlyInstallment,
        int InstallmentMonths,
        DateTime LoanDate,
        DateTime? StartDeductionDate,
        LoanStatus Status,
        int? EmployeeId);
}
