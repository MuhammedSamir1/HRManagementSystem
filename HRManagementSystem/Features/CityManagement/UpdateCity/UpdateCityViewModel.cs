using FluentValidation;

namespace HRManagementSystem.Features.CityManagement.UpdateCity
{
    // ✅ ViewModel اللي هيستقبل البيانات من ال Endpoint
    public sealed record UpdateCityViewModel(Guid Id, string Name, Guid StateId);

    public sealed class UpdateCityViewModelValidator : AbstractValidator<UpdateCityViewModel>
    {
        public UpdateCityViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("City Id is required.")
                .NotEqual(Guid.Empty).WithMessage("City Id must not be empty.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is required.")
                .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.");

            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("State Id is required.")
                .NotEqual(Guid.Empty).WithMessage("State Id must not be empty.");
        }
    }
}
