using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType
{
    // ViewModels/DeleteDisabilityTypeViewModel.cs
    public sealed record DeleteDisabilityTypeViewModel(int Id);

    // Validators/DeleteDisabilityTypeViewModelValidator.cs
    public sealed class DeleteDisabilityTypeViewModelValidator
        : AbstractValidator<DeleteDisabilityTypeViewModel>
    {
        public DeleteDisabilityTypeViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
