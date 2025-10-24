using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.UpdateCity.ViewModels
{
    // ✅ ViewModel اللي هيستقبل البيانات من ال Endpoint
    public sealed record UpdateCityViewModel(int Id, string Name, int StateId);

    public sealed class UpdateCityViewModelValidator : AbstractValidator<UpdateCityViewModel>
    {
        public UpdateCityViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("City Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is required.")
                .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.");

            RuleFor(x => x.StateId)
                .GreaterThan(0).WithMessage("State Id must be greater than 0.");
        }
    }
}
