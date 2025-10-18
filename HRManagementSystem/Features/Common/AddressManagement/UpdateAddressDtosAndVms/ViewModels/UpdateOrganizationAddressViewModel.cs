using FluentValidation;

namespace HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.ViewModels
{
    public sealed record UpdateOrganizationAddressViewModel(int CountryId, int StateId, int CityId,
             string? Street, string? ZipCode);


    public class UpdateOrganizationAddressViewModelValidator : AbstractValidator<UpdateOrganizationAddressViewModel>
    {
        public UpdateOrganizationAddressViewModelValidator()
        {
            RuleFor(x => x.CountryId).GreaterThan(0);
            RuleFor(x => x.StateId).GreaterThan(0);
            RuleFor(x => x.CityId).GreaterThan(0);

            //Street
            RuleFor(x => x.Street)
           .MaximumLength(40).WithMessage("Street must be less than 40 Char!");

            //ZipCode
            RuleFor(x => x.ZipCode)
            .MaximumLength(20)
            .Matches(@"^[A-Za-z0-9\- ]*$")
            .When(x => !string.IsNullOrWhiteSpace(x.ZipCode))
            .WithMessage("Postal code may contain letters, digits, spaces, and dashes only.");
        }
    }
}
