using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService
{
    public sealed record DeleteEndOfServiceViewModel(Guid Id);

    public sealed class DeleteEndOfServiceViewModelValidator : AbstractValidator<DeleteEndOfServiceViewModel>
    {
        public DeleteEndOfServiceViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be a valid GUID.");
        }
    }
}

