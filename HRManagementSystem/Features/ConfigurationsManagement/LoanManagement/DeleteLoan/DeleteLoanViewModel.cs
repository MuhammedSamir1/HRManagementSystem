using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.DeleteLoan
{
    public sealed record DeleteLoanViewModel(Guid Id);

    public sealed class DeleteLoanViewModelValidator : AbstractValidator<DeleteLoanViewModel>
    {
        public DeleteLoanViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



