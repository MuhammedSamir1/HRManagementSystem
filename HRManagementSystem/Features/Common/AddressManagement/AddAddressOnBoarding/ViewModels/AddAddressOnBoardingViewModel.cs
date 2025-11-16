using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.Common.AddressManagement.AddAddressOnBoarding.ViewModels
{
    public sealed class AddAddressOnBoardingRequestViewModel
    {
        [Required]
        public List<CountryOnBoardingViewModel> Countries { get; set; } = new();
    }

    public sealed class CountryOnBoardingViewModel
    {
        [Required]
        [MaxLength(2)]
        public string Iso2 { get; set; } = default!;

        [Required]
        [MaxLength(3)]
        public string Iso3 { get; set; } = default!;

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = default!;

        public List<StateOnBoardingViewModel>? States { get; set; }
    }

    public sealed class StateOnBoardingViewModel
    {
        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = default!;

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = default!;

        public List<CityOnBoardingViewModel>? Cities { get; set; }
    }

    public sealed class CityOnBoardingViewModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = default!;
    }

    public sealed class AddAddressOnBoardingRequestValidator : AbstractValidator<AddAddressOnBoardingRequestViewModel>
    {
        public AddAddressOnBoardingRequestValidator()
        {
            RuleFor(x => x.Countries)
                .NotEmpty()
                .WithMessage("At least one country is required.");

            RuleForEach(x => x.Countries)
                .SetValidator(new CountryOnBoardingViewModelValidator());
        }
    }

    internal sealed class CountryOnBoardingViewModelValidator : AbstractValidator<CountryOnBoardingViewModel>
    {
        public CountryOnBoardingViewModelValidator()
        {
            RuleFor(x => x.Iso2).NotEmpty().Length(2);
            RuleFor(x => x.Iso3).NotEmpty().Length(3);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);

            When(x => x.States != null && x.States.Any(), () =>
            {
                RuleForEach(x => x.States!).SetValidator(new StateOnBoardingViewModelValidator());
            });
        }
    }

    internal sealed class StateOnBoardingViewModelValidator : AbstractValidator<StateOnBoardingViewModel>
    {
        public StateOnBoardingViewModelValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);

            When(x => x.Cities != null && x.Cities.Any(), () =>
            {
                RuleForEach(x => x.Cities!).SetValidator(new CityOnBoardingViewModelValidator());
            });
        }
    }

    internal sealed class CityOnBoardingViewModelValidator : AbstractValidator<CityOnBoardingViewModel>
    {
        public CityOnBoardingViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        }
    }
}


