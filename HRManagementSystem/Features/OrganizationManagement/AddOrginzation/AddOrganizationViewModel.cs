using FluentValidation;
using HRManagementSystem.Features.Common.AddressManagement.AddAddressDtoAndVms.ViewModels;
using HRManagementSystem.Features.Common.CurrencyManagement.AddCurrencyDtosAndVms.ViewModels;

namespace HRManagementSystem.Features.OrganizationManagement
{
    public record AddOrganizationViewModel(string Name, string? LegalName, string? Industry, string? Description,
        DateTime? DefaultTimezone, AddOrganizationCurrencyViewModel Currency, AddOrganizationAddressViewModel Address);

    public class AddOrginizationViewModelValidator : AbstractValidator<AddOrganizationViewModel>
    {
        public AddOrginizationViewModelValidator()
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

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Legal name must be at most 1000 chars.");

            RuleFor(x => x.Industry)
                .MaximumLength(100).WithMessage("Industry must be at most 100 chars.")
                .When(x => !string.IsNullOrWhiteSpace(x.Industry))
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new AddOrganizationAddressViewModelValidator());

            RuleFor(x => x.Currency)
               .NotNull().WithMessage("Currency is required.")
               .SetValidator(new AddOrganizationCurrencyViewModelValidator());
        }
    }
}
