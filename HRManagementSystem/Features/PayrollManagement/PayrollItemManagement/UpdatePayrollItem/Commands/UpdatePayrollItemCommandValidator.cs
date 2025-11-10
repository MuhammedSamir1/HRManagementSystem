using FluentValidation;

namespace HRManagementSystem.Features.PayrollManagement.PayrollItemManagement.UpdatePayrollItem.Commands
{
    public class UpdatePayrollItemCommandValidator : AbstractValidator<UpdatePayrollItemCommand>
    {
        public UpdatePayrollItemCommandValidator()
        {
           
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage(" عنصر المرتب غير صالح.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("يجب إدخال اسم لعنصر المرتب.")
                .MinimumLength(3).WithMessage("يجب أن يكون الاسم على الأقل 3 أحرف.")
                .MaximumLength(100).WithMessage("الاسم لا يجب أن يتجاوز 100 حرف.");
         
            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("نوع البند المُحدد غير صالح.");

            RuleFor(x => x.CalculationType)
                .IsInEnum().WithMessage("نوع الحساب المُحدد غير صالح.");


            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("يجب أن تكون القيمة أكبر من الصفر.");

            When(x => x.CalculationType == CalculationType.PercentageOfBaseSalary, () =>
            {
                RuleFor(x => x.Value)
                    .InclusiveBetween(0.0001m, 1m)
                    .WithMessage("إذا كان نوع الحساب نسبة مئوية، يجب أن تكون القيمة العشرية بين 0.0001 و 1.0.");

      
                RuleFor(x => x.Value)
                    .Must(v => (v * 10000) % 1 == 0)
                    .WithMessage("يجب أن تكون قيمة النسبة المئوية دقيقة بحد أقصى 4 منازل عشرية.");
            });

          
            When(x => x.CalculationType == CalculationType.FixedAmount, () =>
            {
                RuleFor(x => x.Value)
                    .Must(v => (v * 100) % 1 == 0)
                    .WithMessage("القيمة الثابتة يجب أن تكون بحد أقصى منزلتين عشريتين (قيمة مالية).");
            });
        }
    }
}
