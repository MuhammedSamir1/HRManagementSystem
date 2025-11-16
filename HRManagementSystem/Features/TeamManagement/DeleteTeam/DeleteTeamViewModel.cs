using FluentValidation;

namespace HRManagementSystem.Features.TeamManagement.DeleteTeam
{
    public sealed record DeleteTeamViewModel(Guid Id);



    public sealed class DeleteTeamViewModelValidator : AbstractValidator<DeleteTeamViewModel>
    {
        public DeleteTeamViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}


