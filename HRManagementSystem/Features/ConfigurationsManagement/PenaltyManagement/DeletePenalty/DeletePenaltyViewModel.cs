using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty
{
    public sealed record DeletePenaltyViewModel(int Id);

    public sealed class DeletePenaltyViewModelValidator : AbstractValidator<DeletePenaltyViewModel>
    {
        public DeletePenaltyViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

