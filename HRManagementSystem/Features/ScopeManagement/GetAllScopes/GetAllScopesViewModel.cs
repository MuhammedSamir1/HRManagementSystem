using FluentValidation;

namespace HRManagementSystem.Features.ScopeManagement.GetAllScopes
{
    public sealed record GetAllScopesViewModel(int PageNumber = 1, int PageSize = 50);

    public sealed class GetAllScopesViewModelValidator : AbstractValidator<GetAllScopesViewModel>
    {
        public GetAllScopesViewModelValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("PageNumber must be greater than 0.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 200).WithMessage("PageSize must be between 1 and 200.");
        }
    }
}

