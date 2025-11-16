using FluentValidation;

namespace HRManagementSystem.Features.BankManagement.AddBank
{
    public record AddBankRequestViewModel(string Name, string Code, string Address);

    public class AddBankRequestViewModelValidator : AbstractValidator<AddBankRequestViewModel>
    {
        public AddBankRequestViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Name must be at most 200 chars.")
                .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(100).WithMessage("Code must be at most 100 chars.")
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address must be at most 500 chars.")
                .Must(v => v!.Trim().Length <= 500);
        }
    }
}

