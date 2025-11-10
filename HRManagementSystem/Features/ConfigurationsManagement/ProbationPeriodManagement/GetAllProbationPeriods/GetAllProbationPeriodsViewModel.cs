using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.ProbationPeriodManagement.GetAllProbationPeriods
{
    public sealed record GetAllProbationPeriodsViewModel;


    public sealed class GetAllProbationPeriodsViewModelValidator : AbstractValidator<GetAllProbationPeriodsViewModel>
    {
        public GetAllProbationPeriodsViewModelValidator() { }
    }
}

