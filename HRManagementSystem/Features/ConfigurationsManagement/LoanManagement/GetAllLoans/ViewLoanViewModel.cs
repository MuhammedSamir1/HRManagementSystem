namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetAllLoans
{
    public sealed record ViewLoanViewModel(
        Guid Id,
        string Title,
        string? Description,
        decimal Amount,
        decimal RemainingAmount,
        decimal MonthlyInstallment,
        int InstallmentMonths,
        DateTime LoanDate,
        DateTime? StartDeductionDate,
        LoanStatus Status);
}


