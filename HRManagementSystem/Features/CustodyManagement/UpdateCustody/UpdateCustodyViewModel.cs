using FluentValidation;
using HRManagementSystem.Features.CustodyManagement.UpdateCustody.Commands;
using System.ComponentModel.DataAnnotations;

namespace HRManagementSystem.Features.CustodyManagement.UpdateCustody
{
    public record UpdateCustodyViewModel(
    [Required] int Id, 
    string? ItemName,
    string? SerialNumber,
    Guid? EmployeeId, 
    DateTime? HandoverDate,
    DateTime? ReturnDate, 
    string? Status);

    public class UpdateCustodyCommandValidator : AbstractValidator<UpdateCustodyCommand>
    {
        public UpdateCustodyCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("رقم العهدة غير صالح.");

            RuleFor(x => x.ItemName)
                .MaximumLength(250).When(x => !string.IsNullOrWhiteSpace(x.ItemName));

            RuleFor(x => x.SerialNumber)
                .MaximumLength(150).When(x => !string.IsNullOrWhiteSpace(x.SerialNumber));

         
            RuleFor(x => x.EmployeeId)
                .NotEqual(Guid.Empty).When(x => x.EmployeeId.HasValue).WithMessage("يجب تحديد موظف صالح.");

        
            RuleFor(x => x.ReturnDate)
                .LessThanOrEqualTo(DateTime.Today).When(x => x.ReturnDate.HasValue).WithMessage("تاريخ الإرجاع لا يمكن أن يكون في المستقبل.");
        }
    }
}
