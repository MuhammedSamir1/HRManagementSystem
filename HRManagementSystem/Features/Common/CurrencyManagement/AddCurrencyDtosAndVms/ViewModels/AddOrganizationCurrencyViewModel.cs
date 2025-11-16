using FluentValidation;

namespace HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.ViewModels
{
    public sealed record AddOrganizationCurrencyViewModel(Guid CurrencyId);


    public sealed class AddOrganizationCurrencyViewModelValidator : AbstractValidator<AddOrganizationCurrencyViewModel>
    {
        public AddOrganizationCurrencyViewModelValidator()
        {
            RuleFor(x => x.CurrencyId)
                .NotEqual(Guid.Empty).WithMessage("CurrencyId must be greater than 0!");

        }
    }
}




