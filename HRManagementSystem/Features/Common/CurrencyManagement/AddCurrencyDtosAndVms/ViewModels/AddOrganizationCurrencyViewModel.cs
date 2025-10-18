using FluentValidation;

namespace HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.ViewModels
{
    public sealed record AddOrganizationCurrencyViewModel(int CurrencyId);


    public sealed class AddOrganizationCurrencyViewModelValidator : AbstractValidator<AddOrganizationCurrencyViewModel>
    {
        public AddOrganizationCurrencyViewModelValidator()
        {
            RuleFor(x => x.CurrencyId)
                .GreaterThan(0).WithMessage("CurrencyId must be greater than 0!");

        }
    }
}


