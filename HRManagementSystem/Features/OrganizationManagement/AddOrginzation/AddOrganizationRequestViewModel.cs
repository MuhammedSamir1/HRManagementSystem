using FluentValidation;
using HRManagementSystem.Features.Common.AddressManagement;

namespace HRManagementSystem.Features.OrganizationManagement.AddOrginzation
{
    public record AddOrganizationRequestViewModel(string Name, string? LegalName, string? Industry,
        string? DefaultTimezone, string? DefaultCurrency, AddAddressViewModel AddressVM);

    public class AddOrginizationResponseViewModel : AbstractValidator<AddOrganizationRequestViewModel>
    {
        public AddOrginizationResponseViewModel()
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

            RuleFor(x => x.Industry)
                .MaximumLength(100).WithMessage("Industry must be at most 100 chars.")
                .When(x => !string.IsNullOrWhiteSpace(x.Industry))
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.DefaultTimezone)
                .MaximumLength(100).WithMessage("Timezone must be at most 100 chars.")
                .When(x => !string.IsNullOrWhiteSpace(x.DefaultTimezone))
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.DefaultCurrency)
                .Matches("^[A-Za-z]{3}$").WithMessage("Currency must be letters only.")
                .Must(v =>
                {
                    if (string.IsNullOrWhiteSpace(v)) return true;
                    var t = v.Trim();
                    return t.Length == 3
                           && t.All(char.IsLetter)
                           && t == t.ToUpperInvariant();
                })
                .WithMessage("Currency must be a 3-letter UPPERCASE code (e.g., EGP).");

            RuleFor(x => x.AddressVM)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new AddAddressResponseViewModelValidator());
        }
    }
}
