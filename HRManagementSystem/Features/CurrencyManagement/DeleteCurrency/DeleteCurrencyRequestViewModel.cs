using FluentValidation;

namespace HRManagementSystem.Features.CurrencyManagement.DeleteCurrency
{
    public record DeleteCurrencyRequestViewModel(int currencyId);

    public sealed class DeleteCurrencyRequestViewModelValidator : AbstractValidator<DeleteCurrencyRequestViewModel>
    {
        public DeleteCurrencyRequestViewModelValidator()
        {
            RuleFor(d => d.currencyId)
                .NotEmpty().WithMessage("Currency Id is required.")
                .GreaterThan(0).WithMessage("Currency Id must be greater than 0");
        }
    }

}
