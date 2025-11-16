using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.PenaltyManagement.GetPenaltyById
{
    public sealed record GetPenaltyByIdViewModel(Guid Id);

    public sealed class GetPenaltyByIdViewModelValidator : AbstractValidator<GetPenaltyByIdViewModel>
    {
        public GetPenaltyByIdViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id must be greater than 0.");
        }
    }
}



