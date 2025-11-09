using FluentValidation;

namespace HRManagementSystem.Features.BankManagement.GetBankById
{
    public record GetBankByIdRequestViewModel(int Id);

    public class GetBankByIdRequestViewModelValidator : AbstractValidator<GetBankByIdRequestViewModel>
    {
        public GetBankByIdRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

