using FluentValidation;

namespace HRManagementSystem.Features.Common.CurrencyManagement.ViewModels
{
    public sealed record AddOrganizationCurrencyViewModel(int CurrencyId);


    public sealed class AddCurrencyViewModelValidator : AbstractValidator<AddOrganizationCurrencyViewModel>
    {
        public AddCurrencyViewModelValidator()
        {
            RuleFor(x => x.CurrencyId)
                .GreaterThan(0).WithMessage("CurrencyId must be greater than 0!");

        }
    }
}


