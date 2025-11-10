using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.GetBonusById
{
    public sealed record GetBonusByIdViewModel(int Id);

    public sealed class GetBonusByIdViewModelValidator : AbstractValidator<GetBonusByIdViewModel>
    {
        public GetBonusByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

