using FluentValidation;

namespace HRManagementSystem.Features.BankManagement.GetBankById
{
    public record GetBankByIdRequestViewModel(Guid Id);

    public class GetBankByIdRequestViewModelValidator : AbstractValidator<GetBankByIdRequestViewModel>
    {
        public GetBankByIdRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



