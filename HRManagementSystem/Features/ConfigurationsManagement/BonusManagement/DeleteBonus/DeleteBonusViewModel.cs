using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus
{
    public sealed record DeleteBonusViewModel(int Id);

    public sealed class DeleteBonusViewModelValidator : AbstractValidator<DeleteBonusViewModel>
    {
        public DeleteBonusViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

