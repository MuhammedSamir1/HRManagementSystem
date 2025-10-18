using FluentValidation;

namespace HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.ViewModels
{
    public sealed record UpdateOrganizationCurrencyViewModel(int CurrencyId);


    public sealed class UpdateOrganizationCurrencyViewModelValidator : AbstractValidator<UpdateOrganizationCurrencyViewModel>
    {
        public UpdateOrganizationCurrencyViewModelValidator()
        {
            RuleFor(x => x.CurrencyId)
                .GreaterThan(0).WithMessage("CurrencyId must be greater than 0!");

        }
    }
}
