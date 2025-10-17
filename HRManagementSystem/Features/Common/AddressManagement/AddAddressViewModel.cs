using FluentValidation;

namespace HRManagementSystem.Features.Common.AddressManagement
{
    public record AddAddressViewModel(string Country, string City, string Street, string ZipCode);

    public class AddAddressViewModelValidator : AbstractValidator<AddAddressViewModel>
    {
        public AddAddressViewModelValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required!")
                .MaximumLength(30).WithMessage("Country must be less than 30 Char!");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required!")
                .MaximumLength(30).WithMessage("City must be less than 30 Char!");
            RuleFor(x => x.Street).MaximumLength(40).WithMessage("Street must be less than 40 Char!");
            RuleFor(x => x.ZipCode).MaximumLength(20)
                .Matches(@"^[A-Za-z0-9\- ]*$")
                .WithMessage("Postal code may contain letters, digits, spaces, and dashes only.");
        }
    }
}
