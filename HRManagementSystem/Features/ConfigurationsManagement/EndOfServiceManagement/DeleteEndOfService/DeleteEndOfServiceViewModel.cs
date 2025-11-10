using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.EndOfServiceManagement.DeleteEndOfService
{
    public sealed record DeleteEndOfServiceViewModel(int Id);

    public sealed class DeleteEndOfServiceViewModelValidator : AbstractValidator<DeleteEndOfServiceViewModel>
    {
        public DeleteEndOfServiceViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

