
using FluentValidation;


namespace HRManagementSystem.Features.CityManagement.AddCity
{

    public record AddCityViewModel(string Name, int StateId);


    public class AddCityViewModelValidator : AbstractValidator<AddCityViewModel>
    {
        public AddCityViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is required.")
                .MinimumLength(2).WithMessage("City name must be at least 2 characters.")
                .MaximumLength(200).WithMessage("City name must be at most 200 characters.")
                .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.StateId)
                .GreaterThan(0).WithMessage("State is required.");
        }
    }
}
