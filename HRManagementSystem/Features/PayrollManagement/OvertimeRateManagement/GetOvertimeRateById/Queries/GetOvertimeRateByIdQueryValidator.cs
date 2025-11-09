using FluentValidation;

namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.GetOvertimeRateById.Queries
{
    public class GetOvertimeRateByIdQueryValidator : AbstractValidator<GetOvertimeRateByIdQuery>
    {
        public GetOvertimeRateByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("معرّف سعر العمل الإضافي غير صالح.");
        }
    }
}
