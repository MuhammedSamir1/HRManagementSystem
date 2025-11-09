using FluentValidation;

namespace HRManagementSystem.Features.PayrollManagement.OvertimeRateManagement.AddOvertimeRate.Commands
{
    public class AddOvertimeRateCommandValidator : AbstractValidator<AddOvertimeRateCommand>
    {
        public AddOvertimeRateCommandValidator()
        {
       
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم سعر العمل الإضافي مطلوب.")
                .MinimumLength(3).WithMessage("يجب أن يكون الاسم على الأقل 3 أحرف.")
                .MaximumLength(100).WithMessage("الاسم لا يجب أن يتجاوز 100 حرف.");

            // 2. التحقق من معامل السعر (Rate Factor)
            RuleFor(x => x.RateFactor)
                .GreaterThan(1.0m).WithMessage("يجب أن يكون معامل السعر أكبر من 1.0 للعمل الإضافي.");

          
            RuleFor(x => x.RateFactor)
                .Must(v => (v * 100) % 1 == 0)
                .WithMessage("يجب أن يكون معامل السعر بحد أقصى منزلتين عشريتين.");

       
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("الوصف لا يجب أن يتجاوز 500 حرف.");
           
        }
    }
}
