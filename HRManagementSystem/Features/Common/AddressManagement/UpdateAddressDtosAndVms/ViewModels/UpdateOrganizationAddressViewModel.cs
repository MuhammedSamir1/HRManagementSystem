using FluentValidation;

namespace HRManagementSystem.Features.Common.AddressManagement.UpdateAddressDtosAndVms.ViewModels
{
    public sealed record UpdateOrganizationAddressViewModel(Guid CountryId, Guid StateId, Guid CityId,
             string? Street, string? ZipCode);


    public class UpdateOrganizationAddressViewModelValidator : AbstractValidator<UpdateOrganizationAddressViewModel>
    {
        public UpdateOrganizationAddressViewModelValidator()
        {
            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("CountryId is required.")
                .NotEqual(Guid.Empty).WithMessage("CountryId must be provided.");
            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("StateId is required.")
                .NotEqual(Guid.Empty).WithMessage("StateId must be provided.");
            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage("CityId is required.")
                .NotEqual(Guid.Empty).WithMessage("CityId must be provided.");

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

