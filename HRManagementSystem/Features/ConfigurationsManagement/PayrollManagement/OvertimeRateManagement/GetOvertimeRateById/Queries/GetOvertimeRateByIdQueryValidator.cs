using FluentValidation;

namespace HRManagementSystem.Features.ConfigurationsManagement.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById.Queries
{
    public class GetOvertimeRateByIdQueryValidator : AbstractValidator<GetOvertimeRateByIdQuery>
    {
        public GetOvertimeRateByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("????? ??? ????? ??????? ??? ????.");
        }
    }
}
