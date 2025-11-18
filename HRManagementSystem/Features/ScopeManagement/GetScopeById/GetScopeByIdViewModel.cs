using FluentValidation;

namespace HRManagementSystem.Features.ScopeManagement.GetScopeById
{
    public sealed record GetScopeByIdViewModel(Guid Id);

    public sealed class GetScopeByIdViewModelValidator : AbstractValidator<GetScopeByIdViewModel>
    {
        public GetScopeByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be provided.");
        }
    }
}

