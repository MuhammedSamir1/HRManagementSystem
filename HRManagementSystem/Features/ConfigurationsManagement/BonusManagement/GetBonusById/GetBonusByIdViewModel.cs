using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public sealed record GetBonusByIdViewModel(Guid Id);

    public sealed class GetBonusByIdViewModelValidator : AbstractValidator<GetBonusByIdViewModel>
    {
        public GetBonusByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



