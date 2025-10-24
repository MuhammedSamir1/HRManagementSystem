using FluentValidation;

namespace HRManagementSystem.Features.TeamManagement.DeleteTeam
{
    public sealed record DeleteTeamViewModel(int Id);



    public sealed class DeleteTeamViewModelValidator : AbstractValidator<DeleteTeamViewModel>
    {
        public DeleteTeamViewModelValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
