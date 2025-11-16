using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.DisabilityType.DeleteDisabilityType
{
    // ViewModels/DeleteDisabilityTypeViewModel.cs
    public sealed record DeleteDisabilityTypeViewModel(Guid Id);

    // Validators/DeleteDisabilityTypeViewModelValidator.cs
    public sealed class DeleteDisabilityTypeViewModelValidator
        : AbstractValidator<DeleteDisabilityTypeViewModel>
    {
        public DeleteDisabilityTypeViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotEqual(Guid.Empty).WithMessage("ID must be greater than 0.");
        }
    }
}


