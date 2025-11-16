using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById
{
    public sealed record GetLoanByIdViewModel(Guid Id);

    public sealed class GetLoanByIdViewModelValidator : AbstractValidator<GetLoanByIdViewModel>
    {
        public GetLoanByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



