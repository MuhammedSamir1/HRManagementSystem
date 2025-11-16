namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById
{
    public sealed record ViewLoanByIdDto(
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

