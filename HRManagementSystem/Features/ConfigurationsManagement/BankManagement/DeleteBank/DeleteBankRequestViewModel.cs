using FluentValidation;

namespace HRManagementSystem.Features.BankManagement.DeleteBank
{
    public record DeleteBankRequestViewModel(Guid Id);

    public class DeleteBankRequestViewModelValidator : AbstractValidator<DeleteBankRequestViewModel>
    {
        public DeleteBankRequestViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



