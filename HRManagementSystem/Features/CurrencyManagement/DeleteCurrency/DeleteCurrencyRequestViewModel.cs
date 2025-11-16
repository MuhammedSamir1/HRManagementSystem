using FluentValidation;

namespace HRManagementSystem.Features.CurrencyManagement.DeleteCurrency
{
    public record DeleteCurrencyRequestViewModel(Guid currencyId);

    public sealed class DeleteCurrencyRequestViewModelValidator : AbstractValidator<DeleteCurrencyRequestViewModel>
    {
        public DeleteCurrencyRequestViewModelValidator()
        {
            RuleFor(d => d.currencyId)
                .NotEmpty().WithMessage("Currency Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Currency Id must be greater than 0");
        }
    }

}


