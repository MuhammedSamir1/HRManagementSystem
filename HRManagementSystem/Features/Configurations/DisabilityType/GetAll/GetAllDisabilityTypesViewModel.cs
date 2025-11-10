using FluentValidation;

namespace HRManagementSystem.Features.Configurations.DisabilityType.GetAll
{
    // ViewModels/GetAllDisabilityTypesViewModel.cs
    public sealed record GetAllDisabilityTypesViewModel(bool IncludeInactive = false);

    // Validators/GetAllDisabilityTypesViewModelValidator.cs
    public sealed class GetAllDisabilityTypesViewModelValidator
        : AbstractValidator<GetAllDisabilityTypesViewModel>
    {
        public GetAllDisabilityTypesViewModelValidator()
        {
            // Simple validation for boolean parameter
            RuleFor(x => x.IncludeInactive)
                .NotNull().WithMessage("IncludeInactive flag is required.");
        }
    }
}
