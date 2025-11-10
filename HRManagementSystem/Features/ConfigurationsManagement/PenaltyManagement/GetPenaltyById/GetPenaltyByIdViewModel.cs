using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById
{
    public sealed record GetPenaltyByIdViewModel(int Id);

    public sealed class GetPenaltyByIdViewModelValidator : AbstractValidator<GetPenaltyByIdViewModel>
    {
        public GetPenaltyByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

