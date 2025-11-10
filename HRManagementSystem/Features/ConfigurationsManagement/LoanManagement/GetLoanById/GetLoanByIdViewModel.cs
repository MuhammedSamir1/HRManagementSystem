using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.LoanManagement.GetLoanById
{
    public sealed record GetLoanByIdViewModel(int Id);

    public sealed class GetLoanByIdViewModelValidator : AbstractValidator<GetLoanByIdViewModel>
    {
        public GetLoanByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

