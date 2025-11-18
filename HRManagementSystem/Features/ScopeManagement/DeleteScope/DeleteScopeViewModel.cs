using FluentValidation;

namespace HRManagementSystem.Features.ScopeManagement.DeleteScope
{
    public sealed record DeleteScopeViewModel(Guid Id);

    public sealed class DeleteScopeViewModelValidator : AbstractValidator<DeleteScopeViewModel>
    {
        public DeleteScopeViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be provided.");
        }
    }
}

