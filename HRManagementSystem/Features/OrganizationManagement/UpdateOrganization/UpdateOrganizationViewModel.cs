using FluentValidation;
using HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.UpdateCurrencyDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.OrganizationManagement.UpdateOrganization
{
    public sealed record UpdateOrganizationViewModel(int Id, string Name, string? LegalName, string? Industry, string? Descreption,
         UpdateOrganizationCurrencyViewModel Currency, UpdateOrganizationAddressViewModel Address);



    public class UpdateOrganizationViewModelValidator : AbstractValidator<UpdateOrganizationViewModel>
    {
        public UpdateOrganizationViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
                .MaximumLength(200).WithMessage("Name must be at most 200 chars.")
                .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.LegalName)
                .MaximumLength(200).WithMessage("Legal name must be at most 200 chars.")
                .When(x => !string.IsNullOrWhiteSpace(x.LegalName))
                .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.Descreption)
                .MaximumLength(1000).WithMessage("Legal name must be at most 1000 chars.");

            RuleFor(x => x.Industry)
                .MaximumLength(100).WithMessage("Industry must be at most 100 chars.")
                .When(x => !string.IsNullOrWhiteSpace(x.Industry))
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new UpdateOrganizationAddressViewModelValidator());

            RuleFor(x => x.Currency)
                .NotNull().WithMessage("Currency is required.")
                .SetValidator(new UpdateOrganizationCurrencyViewModelValidator());
        }
    }
}
