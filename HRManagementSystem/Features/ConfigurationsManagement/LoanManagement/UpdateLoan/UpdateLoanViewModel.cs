using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.UpdateLoan
{
    public sealed record UpdateLoanViewModel(
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

    public sealed class UpdateLoanViewModelValidator : AbstractValidator<UpdateLoanViewModel>
    {
        public UpdateLoanViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Title must be at most 200 chars.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be at most 1000 chars.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.RemainingAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Remaining amount must be 0 or greater.");

            RuleFor(x => x.MonthlyInstallment)
                .GreaterThan(0).WithMessage("Monthly installment must be greater than 0.");

            RuleFor(x => x.InstallmentMonths)
                .GreaterThan(0).WithMessage("Installment months must be greater than 0.");

            RuleFor(x => x.LoanDate)
                .NotEmpty().WithMessage("Loan date is required.");
        }
    }
}

