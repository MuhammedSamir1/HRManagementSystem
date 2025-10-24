using FluentValidation;

namespace HRManagementSystem.Features.StateManagement.DeleteState
{
    public sealed record DeleteStateViewModel
    {
        public int Id { get; init; }
    }
    public sealed class DeleteStateViewModelValidator : AbstractValidator<DeleteStateViewModel>
    {
        public DeleteStateViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
