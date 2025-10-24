using FluentValidation;

namespace HRManagementSystem.Features.TeamManagement.GetAllTeams
{
    public sealed record GetAllTeamsViewModel;


    public sealed class GetAllTeamsViewModelValidator : AbstractValidator<GetAllTeamsViewModel>
    {
        public GetAllTeamsViewModelValidator() { }
    }
}
