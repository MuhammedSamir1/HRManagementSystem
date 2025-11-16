using FluentValidation;

namespace HRManagementSystem.Features.TeamManagement.AddTeam
{
    public sealed record AddTeamViewModel(string Name, string Code, string? Description, Guid DepartmentId);


    public sealed class AddTeamViewModelValidator : AbstractValidator<AddTeamViewModel>
    {
        public AddTeamViewModelValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Name is required.")
              .MinimumLength(2).WithMessage("Name must be at least 2 chars.")
              .MaximumLength(200).WithMessage("Name must be at most 200 chars.")
              .Must(v => v!.Trim().Length <= 200);

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(100).WithMessage("Code must be at most 100 chars.")
                .MaximumLength(200).WithMessage("Code must be at most 200 chars.")
                .Must(v => v!.Trim().Length <= 100);

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Legal name must be at most 1000 chars.");

            RuleFor(x => x.DepartmentId)
               .NotEmpty().WithMessage("DepartmentId is required.")
               .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}


