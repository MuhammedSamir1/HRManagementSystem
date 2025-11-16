using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.BonusManagement.DeleteBonus
{
    public sealed record DeleteBonusViewModel(Guid Id);

    public sealed class DeleteBonusViewModelValidator : AbstractValidator<DeleteBonusViewModel>
    {
        public DeleteBonusViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



