using FluentValidation;

namespace HRManagementSystem.Features.TeamManagement.GetTeamById
{
    public sealed record GetTeamByIdViewModel(Guid Id);


    public sealed class GetTeamByIdViewModelValidator : AbstractValidator<GetTeamByIdViewModel>
    {
        public GetTeamByIdViewModelValidator()
        {
            RuleFor(d => d.Id)
              .NotEmpty().WithMessage("Id is required.")
              .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0");
        }
    }
}


