using FluentValidation;

namespace HRManagementSystem.Features.StateManagement.DeleteState
{
    public sealed record DeleteStateViewModel
    {
        public Guid Id { get; init; }
    }
    public sealed class DeleteStateViewModelValidator : AbstractValidator<DeleteStateViewModel>
    {
        public DeleteStateViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotEqual(Guid.Empty).WithMessage("ID must not be empty.");
        }
    }
}
