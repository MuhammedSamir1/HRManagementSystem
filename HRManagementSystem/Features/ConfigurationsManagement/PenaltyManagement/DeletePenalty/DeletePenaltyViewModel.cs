using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.DeletePenalty
{
    public sealed record DeletePenaltyViewModel(Guid Id);

    public sealed class DeletePenaltyViewModelValidator : AbstractValidator<DeletePenaltyViewModel>
    {
        public DeletePenaltyViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



