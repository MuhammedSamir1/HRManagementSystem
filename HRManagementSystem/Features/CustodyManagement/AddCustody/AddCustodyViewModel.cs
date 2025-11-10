using FluentValidation;

namespace HRManagementSystem.Features.CustodyManagement.AddCustody
{
    public record AddCustodyViewModel(
     string ItemName,
     string SerialNumber,
     Guid EmployeeId,
     DateTime HandoverDate);
    public class AddCustodyCommandValidator : AbstractValidator<AddCustodyViewModel>
    {
        public AddCustodyCommandValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty().WithMessage("اسم العهدة مطلوب.").MaximumLength(250);
            RuleFor(x => x.SerialNumber).NotEmpty().WithMessage("الرقم التسلسلي مطلوب.").MaximumLength(150);
            RuleFor(x => x.EmployeeId)
                            .NotEmpty() 
                            .NotEqual(Guid.Empty).WithMessage("يجب تحديد موظف صالح (EmployeeId).");
            RuleFor(x => x.HandoverDate).LessThanOrEqualTo(DateTime.Today).WithMessage("تاريخ التسليم لا يمكن أن يكون في المستقبل.");
        }
    }
}
