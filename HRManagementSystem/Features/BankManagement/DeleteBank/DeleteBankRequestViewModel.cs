using FluentValidation;

namespace HRManagementSystem.Features.BankManagement.DeleteBank
{
    public record DeleteBankRequestViewModel(int Id);

    public class DeleteBankRequestViewModelValidator : AbstractValidator<DeleteBankRequestViewModel>
    {
        public DeleteBankRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

