using FluentValidation;

namespace HRManagementSystem.Features.TeamManagement.GetTeamById
{
    public sealed record GetTeamByIdViewModel(int Id);


    public sealed class GetTeamByIdViewModelValidator : AbstractValidator<GetTeamByIdViewModel>
    {
        public GetTeamByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
