using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan
{
    public sealed record DeleteLoanViewModel(int Id);

    public sealed class DeleteLoanViewModelValidator : AbstractValidator<DeleteLoanViewModel>
    {
        public DeleteLoanViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

